package gigapi;

import android.app.Activity;
import android.content.ClipData;
import android.os.Handler;
import android.os.SystemClock;
import android.webkit.WebIconDatabase;
import android.widget.ArrayAdapter;
import com.example.gig.application.utility.DeviceArrayAdapter;
import gigapi.support.UPNPstrings;
import android.util.Log;
import org.fourthline.cling.android.AndroidUpnpService;
import org.fourthline.cling.android.AndroidUpnpServiceImpl;
import org.fourthline.cling.binding.xml.Descriptor;
import org.fourthline.cling.controlpoint.ControlPoint;
import org.fourthline.cling.controlpoint.SubscriptionCallback;
import org.fourthline.cling.model.ModelUtil;
import org.fourthline.cling.model.ValidationException;
import org.fourthline.cling.model.action.ActionInvocation;
import org.fourthline.cling.model.gena.CancelReason;
import org.fourthline.cling.model.gena.GENASubscription;
import org.fourthline.cling.model.message.UpnpResponse;
import org.fourthline.cling.model.meta.Device;
import org.fourthline.cling.model.meta.RemoteDevice;
import org.fourthline.cling.model.types.UnsignedIntegerFourBytes;
import org.fourthline.cling.support.avtransport.callback.*;
import org.fourthline.cling.support.avtransport.lastchange.AVTransportVariable;
import org.fourthline.cling.support.contentdirectory.callback.Browse;
import org.fourthline.cling.support.model.*;
import org.fourthline.cling.support.model.container.Album;
import org.fourthline.cling.support.model.container.Container;
import org.fourthline.cling.support.model.item.Item;
import org.fourthline.cling.support.renderingcontrol.callback.SetMute;
import org.fourthline.cling.support.renderingcontrol.callback.SetVolume;

import java.util.ArrayList;
import java.util.Collection;
import java.util.InputMismatchException;
import java.util.List;

/**
 * Created by Kees Bank on 6/19/2014.
 *
 */
public class Controller implements IController {

    protected AndroidUpnpService upnpService;

    // Lists containing devices TODO make devices Render and Server
    private ArrayList<Server> serverList = new ArrayList<>();
    private ArrayList<Renderer> rendererList = new ArrayList<>();


    // Position Info track
    public PositionInfo currentInfo;
    public List<Item> playlist = new ArrayList<>();
    public TransportInfo rendererState;

    //
    public Controller(AndroidUpnpService upnpService, DeviceArrayAdapter arrayAdapter){
        this.upnpService = upnpService;
        upnpService.getRegistry().addListener(arrayAdapter);
    }

    // TODO make devices Renderer and Server
    public ArrayList<Server> getServers(){
        return serverList;
    }
    public ArrayList<Renderer> getRenderers(){
        return rendererList;
    }



    public void searchDevices(){
        // Start Asynchronous Search for UPnP devices
        upnpService.getControlPoint().search();
    }


    // Plays a Track on the given Renderer
    public void play(Device renderer, Item track){
        upnpService.getControlPoint().execute(
                new SetAVTransportURI(new UnsignedIntegerFourBytes(0),
                        renderer.findService(UPNPstrings.SUPPORT_AV_TRANSPORT_TYPE), track.getFirstResource().getValue()) {
                    @Override
                    public void failure(ActionInvocation invocation, UpnpResponse upnpResponse, String s) {
                        System.out.println("SetAVUri");
                        System.out.println(s);
                        System.out.println(upnpResponse.getResponseDetails());
                    }
                }
        );
        SystemClock.sleep(5000);
        // Set Renderer to Play with ID = 0
        upnpService.getControlPoint().execute(new Play(new UnsignedIntegerFourBytes(0) ,renderer.findService(UPNPstrings.SUPPORT_AV_TRANSPORT_TYPE)) {
            @Override
            public void failure(ActionInvocation invocation, UpnpResponse upnpResponse, String s) {
                Log.i("System.out", "Play:" + upnpResponse.getResponseDetails());
            }
        });

    }


    //Pauses  playback on the given Renderer
    public void pause(Device renderer){
        upnpService.getControlPoint().execute(new Pause(new UnsignedIntegerFourBytes(0),
                renderer.findService(UPNPstrings.SUPPORT_AV_TRANSPORT_TYPE)) {
            @Override
            public void failure(ActionInvocation invocation, UpnpResponse upnpResponse, String s) {
                Log.i("System.out", "Pause:" + upnpResponse.getResponseDetails());
            }
        });
    }

    // Resumes playback
    public void resume(Device renderer){
        upnpService.getControlPoint().execute(new Play(new UnsignedIntegerFourBytes(0),
                renderer.findService(UPNPstrings.SUPPORT_AV_TRANSPORT_TYPE)) {
            @Override
            public void failure(ActionInvocation invocation, UpnpResponse operation, String defaultMsg) {
                Log.i("System.out", "Resuming:" + operation.getResponseDetails());
            }
        });
    }

    @Override
    public void previous(Device renderer) {
        upnpService.getControlPoint().execute(new Seek(new UnsignedIntegerFourBytes(0),
                renderer.findService(UPNPstrings.SUPPORT_AV_TRANSPORT_TYPE),
                SeekMode.ABS_TIME,
                currentInfo.getTrackDuration()
                ) {
            @Override
            public void failure(ActionInvocation invocation, UpnpResponse operation, String defaultMsg) {

            }
        });
    }

    // Plays next Track
    @Override
    public void next(Device renderer) {
        upnpService.getControlPoint().execute(new Seek(new UnsignedIntegerFourBytes(0),
                renderer.findService(UPNPstrings.SUPPORT_AV_TRANSPORT_TYPE),
                SeekMode.ABS_TIME,
                currentInfo.getTrackDuration()
                ) {
            @Override
            public void failure(ActionInvocation invocation, UpnpResponse operation, String defaultMsg) {

            }
        });
    }

    // Set Renderer Volume
    public void setVolume(Device renderer, int value){
        upnpService.getControlPoint().execute(
                new SetVolume(renderer.findService(UPNPstrings.SUPPORT_RENDERING_CONTROL_TYPE), value) {
                    @Override
                    public void failure(ActionInvocation invocation, UpnpResponse upnpResponse, String s) {
                        Log.i("System.out", "Volume" + upnpResponse.getResponseDetails());
                    }
                }
        );
    }





    // Mutes the given Renderer
    public void mute(Device renderer){
        upnpService.getControlPoint().execute(new SetMute(renderer.findService(UPNPstrings.SUPPORT_RENDERING_CONTROL_TYPE), true) {
            @Override
            public void failure(ActionInvocation invocation, UpnpResponse upnpResponse, String s) {
                Log.i("System.out", "Mute:" + upnpResponse.getResponseDetails());
            }
        });
    }




   // Browse the rootdirectory of a given server and put it in an Adapter
   public void browseRoot(Device server, Activity activity, String currentdir, ArrayAdapter arrayAdapter){
       upnpService.getControlPoint().execute(
               new Browse(server.findService(UPNPstrings.SUPPORT_CONTENT_DIRECTORY_TYPE),
                       "0", BrowseFlag.DIRECT_CHILDREN) {

           @Override
           public void received(ActionInvocation invocation, DIDLContent didlContent) {
                activity.runOnUiThread(new Runnable() {
                    @Override
                    public void run() {
                        arrayAdapter.clear();
                        for (Container container : didlContent.getContainers()) {
                            arrayAdapter.add(container);
                        }
                        for (Item i : didlContent.getItems()) {
                            arrayAdapter.add(i);
                        }
                    }
                });


           }

           @Override
           public void updateStatus(Status status) {
              Log.i("System.out", "Status Browse:" + status.getDefaultMessage());
           }

           @Override
           public void failure(ActionInvocation invocation, UpnpResponse upnpResponse, String s) {
               Log.i("System.out", "Browsing root:" + upnpResponse.getResponseDetails());
           }
       });
   }

    // Browse a folder on a Server
    public void browseFolder(Device server, Activity activity, String currentdir, ArrayAdapter arrayAdapter){
        upnpService.getControlPoint().execute(
                new Browse(server.findService(UPNPstrings.SUPPORT_CONTENT_DIRECTORY_TYPE),
                        currentdir, BrowseFlag.DIRECT_CHILDREN) {

                    @Override
                    public void received(ActionInvocation invocation, DIDLContent didlContent) {
                        activity.runOnUiThread(new Runnable() {
                            @Override
                            public void run() {
                                arrayAdapter.clear();
                                for(Container container : didlContent.getContainers()){
                                    arrayAdapter.add(container);
                                }
                                for(Item i : didlContent.getItems()){
                                    arrayAdapter.add(i);
                                }
                            }
                        });

                    }

                    @Override
                    public void updateStatus(Status status) {
                        Log.i("System.out", "Status Browse:" + status.getDefaultMessage());
                    }

                    @Override
                    public void failure(ActionInvocation invocation, UpnpResponse upnpResponse, String s) {
                        Log.i("System.out", "Browsing:" + upnpResponse.getResponseDetails());
                    }
                });
    }

    // Polls a Renderer's AVtransport for Position info
    public void pollAVtransport(Device renderer){
                    upnpService.getControlPoint().execute(
                            new GetPositionInfo(new UnsignedIntegerFourBytes(0), renderer.findService(UPNPstrings.SUPPORT_AV_TRANSPORT_TYPE)) {
                                @Override
                                public void received(ActionInvocation invocation, PositionInfo positionInfo) {
                                    Log.i("System.out", "Received yes sir");
                                    currentInfo = positionInfo;

                                }

                                @Override
                                public void failure(ActionInvocation invocation, UpnpResponse operation, String defaultMsg) {

                                }
                            }
                    );

        new Handler().postDelayed(new Runnable() {
            @Override
            public void run() {
                pollAVtransport(renderer);
            }
        }, 1000);

    }

    // Poll A Renderer's Transport State for Playback State
    public void pollTransportState(Device renderer){
        upnpService.getControlPoint().execute(
                new GetTransportInfo(new UnsignedIntegerFourBytes(0), renderer.findService(UPNPstrings.SUPPORT_AV_TRANSPORT_TYPE)) {
                    @Override
                    public void received(ActionInvocation invocation, TransportInfo transportInfo) {
                        rendererState = transportInfo;
                    }

                    @Override
                    public void failure(ActionInvocation invocation, UpnpResponse operation, String defaultMsg) {
                        Log.i("System.out", "Transportinfo:" + operation.getResponseDetails());
                    }
                }
        );

        new Handler().postDelayed(new Runnable() {
            @Override
            public void run() {
                pollTransportState(renderer);
            }
        }, 1000);
    }

    // Seek to Current RelativePosition + Time in seconds(progress)
    public void seek(Device renderer,  long progress){
        upnpService.getControlPoint().execute(
                new Seek(new UnsignedIntegerFourBytes(0), renderer.findService(UPNPstrings.SUPPORT_AV_TRANSPORT_TYPE),
                        SeekMode.REL_TIME,
                        ModelUtil.toTimeString(progress)) {
                    @Override
                    public void failure(ActionInvocation invocation, UpnpResponse operation, String defaultMsg) {
                        Log.i("System.out", "Seeking:" + operation.getResponseDetails());

                    }
                }
        );
        currentInfo = new PositionInfo(currentInfo,
                ModelUtil.toTimeString(currentInfo.getTrackElapsedSeconds() + progress),
                ModelUtil.toTimeString(currentInfo.getTrackElapsedSeconds() + progress)
        );
    }




}
