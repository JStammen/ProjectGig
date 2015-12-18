package com.example.gig.application.gui;

import android.bluetooth.BluetoothClass;
import android.content.ComponentName;
import android.content.Context;
import android.content.Intent;
import android.content.ServiceConnection;
import android.os.Bundle;
import android.os.IBinder;
import android.os.SystemClock;
import android.support.v4.app.ListFragment;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ListView;
import com.example.GIGUPnPController.R;
import com.example.gig.application.utility.DeviceArrayAdapter;
import com.example.gig.application.utility.FileArrayAdapter;
import gigapi.Controller;
import gigapi.Server;
import org.fourthline.cling.Main;
import org.fourthline.cling.android.AndroidUpnpService;
import org.fourthline.cling.android.AndroidUpnpServiceImpl;
import org.fourthline.cling.model.ValidationException;
import org.fourthline.cling.model.meta.Device;
import org.fourthline.cling.support.model.container.Container;
import org.fourthline.cling.support.model.item.Item;

import java.util.ArrayList;
import java.util.List;

/**
 * Created by Kees Bank on 6/16/2014.
 */
public class ServerFragment extends ListFragment {

    // For Displaying Servers and Folders/Items
    private DeviceArrayAdapter serverDisplayAdapter;
    private FileArrayAdapter fileArrayAdapter;

    public Controller controller;

    public Device<?,?,?> currentServer;
    public String currentdir;

    // Current Server & Path


    private ServiceConnection serviceConnection = new ServiceConnection() {
        @Override
        public void onServiceConnected(ComponentName name, IBinder service){
            controller = new Controller((AndroidUpnpService) service, serverDisplayAdapter);
            controller.searchDevices();
        }

        @Override
        public void onServiceDisconnected(ComponentName name) {
            controller = null;
        }
    };

    @Override
    public void onActivityCreated(Bundle savedInstanceState){
        super.onActivityCreated(savedInstanceState);

        serverDisplayAdapter = new DeviceArrayAdapter(getActivity(), DeviceArrayAdapter.SERVER);
        fileArrayAdapter = new FileArrayAdapter(getActivity());
        setListAdapter(serverDisplayAdapter);


        getActivity().getApplicationContext().bindService(
                new Intent(getActivity(), AndroidUpnpServiceImpl.class),
                serviceConnection,
                Context.BIND_AUTO_CREATE);
    }

    @Override
    public void onListItemClick(ListView l, View v, int position, long id){
        if(getListAdapter() == serverDisplayAdapter){
            browseMode(serverDisplayAdapter.getItem(position));
        }else if(getListAdapter() == fileArrayAdapter) {
            if (fileArrayAdapter.getItem(position) instanceof Container)
                browsing(position);
            else {
                Log.i("System.out", "yay");
                List<Item> playlist = new ArrayList<Item>();
                for (int i = 0; i < fileArrayAdapter.getCount(); i++) {
                    if (fileArrayAdapter.getItem(i) instanceof Item) {
                        playlist.add((Item) fileArrayAdapter.getItem(i));
                    }
                }
                MainActivity activity = (MainActivity) getActivity();
                activity.play(playlist, position);
            }
        }
    }

    private void browseMode(Device server){
        setListAdapter(fileArrayAdapter);
        currentServer = server;
        controller.browseRoot(server, getActivity(), currentdir, fileArrayAdapter);
    }

    private void browsing(int position){
        controller.browseFolder(currentServer, getActivity(), fileArrayAdapter.getItem(position).getId(),
                fileArrayAdapter);
    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        return inflater.inflate(R.layout.server_fragment, null);
    };
}
