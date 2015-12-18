package gigapi;


import android.app.Activity;
import org.fourthline.cling.model.Namespace;
import org.fourthline.cling.model.Validatable;
import org.fourthline.cling.model.ValidationException;
import org.fourthline.cling.model.meta.*;
import org.fourthline.cling.model.resource.Resource;
import org.fourthline.cling.model.types.DeviceType;
import org.fourthline.cling.model.types.ServiceId;
import org.fourthline.cling.model.types.ServiceType;
import org.fourthline.cling.model.types.UDN;


import java.net.URI;
import java.util.ArrayList;
import java.util.Collection;
import java.util.List;


/**
 * Created by Kees Bank on 6/19/2014.
 */
public class Server
{

    public ArrayList<Track> tracks;

    public Device<?, ?, ?> serverDevice;

    public Activity currentActivity;

    public String currentDirectory = "0";


    // Default Constructor
    public Server(Device device, Activity activity)
    {
        serverDevice = device;
        currentActivity = activity;
    }

    public String getCurrentDirectory() {
        return currentDirectory;
    }




    public Device getServerDevice() {
        return serverDevice;
    }

}
