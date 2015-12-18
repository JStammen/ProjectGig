package gigapi;


import org.fourthline.cling.model.Namespace;
import org.fourthline.cling.model.ValidationException;
import org.fourthline.cling.model.meta.*;
import org.fourthline.cling.model.resource.Resource;
import org.fourthline.cling.model.types.DeviceType;
import org.fourthline.cling.model.types.ServiceId;
import org.fourthline.cling.model.types.ServiceType;
import org.fourthline.cling.model.types.UDN;

import java.net.URI;
import java.util.Collection;
import java.util.List;


/**
 * Created by kb on 6/19/2014.
 */
public class Renderer {

    public Device renderer;
    public Track currentTrack;

    // status fields
    public int currentVolume;
    public boolean isPlaying = false;



}
