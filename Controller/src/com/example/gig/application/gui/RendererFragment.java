package com.example.gig.application.gui;

import android.app.Service;
import android.content.*;
import android.graphics.Color;
import android.os.Bundle;
import android.os.Handler;
import android.os.IBinder;
import android.os.SystemClock;
import android.support.v4.app.ListFragment;
import android.support.v7.app.MediaRouteDiscoveryFragment;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.*;
import com.example.GIGUPnPController.R;
import com.example.gig.application.utility.DeviceArrayAdapter;
import com.example.gig.application.utility.FileArrayAdapter;
import gigapi.Controller;
import gigapi.Track;
import org.fourthline.cling.android.AndroidUpnpService;
import org.fourthline.cling.android.AndroidUpnpServiceImpl;
import org.fourthline.cling.model.ModelUtil;
import org.fourthline.cling.model.meta.Device;
import org.fourthline.cling.support.model.PositionInfo;
import org.fourthline.cling.support.model.TransportState;
import org.fourthline.cling.support.model.container.Container;
import org.fourthline.cling.support.model.item.Item;

import java.util.ArrayList;
import java.util.List;
import java.util.Random;

/**
 * Created by Kees Bank on 6/16/2014.
 */
public class RendererFragment extends ListFragment implements View.OnClickListener, SeekBar.OnSeekBarChangeListener, AbsListView.OnScrollListener {

    public Controller controller;

    public DeviceArrayAdapter deviceArrayAdapter;
    public FileArrayAdapter fileArrayAdapter;

    public Device<?, ?, ?> selectedRenderer;
    public List<Item> currentPlayList;
    int currentTrack;

    private View mControls;
    private SeekBar mProgressBar;
    private ImageButton mPlayPause;
    private ImageButton mShuffle;
    private ImageButton mRepeat;
    private TextView mCurrentTimeView;
    private TextView mTotalTimeView;

    private View mCurrentTrackView;

    private volatile boolean playing;



    private ServiceConnection serviceConnection = new ServiceConnection() {
        @Override
        public void onServiceConnected(ComponentName name, IBinder service) {
            controller = new Controller((AndroidUpnpService) service, deviceArrayAdapter);
            controller.searchDevices();
        }

        @Override
        public void onServiceDisconnected(ComponentName name) {

        }
    };


    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {

        return inflater.inflate(R.layout.route_fragment, null);
    }

    ;


    @Override
    public void onActivityCreated(Bundle savedInstancestate) {
        super.onActivityCreated(savedInstancestate);

        deviceArrayAdapter = new DeviceArrayAdapter(getActivity(), "MediaRenderer");
        fileArrayAdapter = new FileArrayAdapter(getActivity());
        setListAdapter(deviceArrayAdapter);

        // GUI
        mControls = getView().findViewById(R.id.controls);
        mProgressBar = (SeekBar) getView().findViewById(R.id.progressBar);
        mProgressBar.setOnSeekBarChangeListener(this);

        // Shuffle
        mShuffle = (ImageButton) getView().findViewById(R.id.shuffle);
        mShuffle.setImageResource(R.drawable.ic_action_shuffle);
        mShuffle.setOnClickListener(this);

        // Previous
        ImageButton previous = (ImageButton) getView().findViewById(R.id.previous);
        previous.setImageResource(R.drawable.ic_action_previous);
        previous.setOnClickListener(this);

        // Next
        ImageButton next = (ImageButton) getView().findViewById(R.id.next);
        next.setImageResource(R.drawable.ic_action_next);
        next.setOnClickListener(this);

        // Repeat
        mRepeat = (ImageButton) getView().findViewById(R.id.repeat);
        mRepeat.setImageResource(R.drawable.ic_action_repeat);
        mRepeat.setOnClickListener(this);

        // Play-Pause
        mPlayPause = (ImageButton) getView().findViewById(R.id.playpause);
        mPlayPause.setImageResource(R.drawable.ic_action_play);
        mPlayPause.setOnClickListener(this);

        // Time
        mCurrentTimeView = (TextView) getView().findViewById(R.id.current_time);
        mTotalTimeView = (TextView) getView().findViewById(R.id.total_time);

        getActivity().getApplicationContext().bindService(
                new Intent(getActivity(), AndroidUpnpServiceImpl.class),
                serviceConnection,
                Context.BIND_AUTO_CREATE);


    }

    @Override
    public void onListItemClick(ListView l, View v, int position, long id) {
        if (getListAdapter() == deviceArrayAdapter) {
            playlistMode(deviceArrayAdapter.getItem(position));
        } else {
            controller.play(selectedRenderer, currentPlayList.get(position));
            updatePlayPause(true);
        }
    }

    public void playlistMode(Device device) {
        selectedRenderer = device;
        setListAdapter(fileArrayAdapter);
        mControls.setVisibility(View.VISIBLE);

    }

    public void play(List<Item> playlist, int start) {
        playing = true;
        currentPlayList = playlist;
        currentTrack = start;

        fileArrayAdapter.clear();
        fileArrayAdapter.add(playlist);
        Log.i("System.out", selectedRenderer.getDisplayString());
        controller.play(selectedRenderer, playlist.get(start));
        currentTrack ++;
        playBackStatus();

    }

    public void playNext(){
        Log.i("System.out", "Now playing Track:" + currentTrack);
        controller.play(selectedRenderer, currentPlayList.get(currentTrack));
        if(currentTrack == currentPlayList.size()){
            currentTrack = 0;
        }else {
            currentTrack ++;
        }

    }

    public void shuffle(){
        controller.play(selectedRenderer,
                currentPlayList.get(new Random().nextInt(currentPlayList.size())));
    }

    @Override
    public void onClick(View v) {
        switch (v.getId()) {
            case R.id.playpause:
                if (playing) {
                    controller.pause(selectedRenderer);
                    updatePlayPause(false);
                } else {
                    controller.resume(selectedRenderer);
                    updatePlayPause(true);
                }
                break;
            case R.id.shuffle:
                if(playing){
                    shuffle();
                }
                break;
            case R.id.previous:
                currentTrack --;
                playNext();
                break;
            case R.id.next:
                currentTrack ++;
                playNext();
                break;
            case R.id.repeat:
                currentTrack --;
                playNext();

        }

    }


    public void playBackStatus() {
        controller.pollAVtransport(selectedRenderer);
        controller.pollTransportState(selectedRenderer);
        // TODO make this nicer
        SystemClock.sleep(2000);
        updateTimer();
        updateRendererState();

    }

    public void updateTimer(){
        // Info for me
        Log.i("System.out", controller.currentInfo.getTrackDuration());
        Log.i("System.out", controller.currentInfo.getRelTime());

        mCurrentTimeView.setText(controller.currentInfo.getRelTime());
        mTotalTimeView.setText(controller.currentInfo.getTrackDuration());

        long test = ModelUtil.fromTimeString(controller.currentInfo.getRelTime());
        long test2 = ModelUtil.fromTimeString(controller.currentInfo.getTrackDuration());

        mProgressBar.setProgress((int)test);
        mProgressBar.setMax((int)test2);

        new Handler().postDelayed(new Runnable() {
            @Override
            public void run() {
                updateTimer();
            }
        }, 1000);

    }

    public void updateRendererState(){
        if(controller.rendererState.getCurrentTransportState() == TransportState.STOPPED && playing){
            playNext();
        }


        new Handler().postDelayed(new Runnable() {
            @Override
            public void run() {
                updateRendererState();
            }
        }, 2000);
    }

    public void updatePlayPause(boolean set){
        playing = set;
        if(set){
            mPlayPause.setImageResource(R.drawable.ic_action_pause);
            mPlayPause.setContentDescription(getResources().getString(R.string.pause));
        }else{
            mPlayPause.setImageResource(R.drawable.ic_action_play);
            mPlayPause.setContentDescription(getResources().getString(R.string.play));
        }
    }


    // Seek Bar
    @Override
    public void onProgressChanged(SeekBar seekBar, int progress, boolean fromUser) {
        if(fromUser && playing){
            Log.i("System.out", "Yay " +progress);
            controller.seek(selectedRenderer, (long)progress);
        }
    }

    @Override
    public void onStartTrackingTouch(SeekBar seekBar) {

    }

    @Override
    public void onStopTrackingTouch(SeekBar seekBar) {

    }

    // Track Highlighting
    private void enableTrackHighlight() {
        if (getListAdapter() == deviceArrayAdapter ||
                selectedRenderer == null)
            return;

        disableTrackHighlight();
        mCurrentTrackView = getListView().getChildAt(currentTrack
                - getListView().getFirstVisiblePosition() + getListView().getHeaderViewsCount());
        if (mCurrentTrackView != null) {
            mCurrentTrackView.setBackgroundColor(
                    getResources().getColor(Color.BLUE));
        }
    }

    private void disableTrackHighlight() {
        if (mCurrentTrackView != null) {
            mCurrentTrackView.setBackgroundColor(Color.TRANSPARENT);
        }
    }


    @Override
    public void onScrollStateChanged(AbsListView view, int scrollState) {
        enableTrackHighlight();
    }

    @Override
    public void onScroll(AbsListView view, int firstVisibleItem, int visibleItemCount, int totalItemCount) {
        enableTrackHighlight();
    }
}