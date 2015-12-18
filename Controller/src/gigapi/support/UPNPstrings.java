package gigapi.support;

import org.fourthline.cling.model.types.DeviceType;
import org.fourthline.cling.model.types.ServiceType;
import org.fourthline.cling.model.types.UDADeviceType;
import org.fourthline.cling.model.types.UDAServiceType;

/**
 * Created by Kb on 6/3/2014.
 */
public class UPNPstrings {

    // Services
    public static final ServiceType SUPPORTED_CONNECTION_MGR_TYPE = new UDAServiceType("ConnectionManager", 1);

    public static final ServiceType SUPPORT_CONTENT_DIRECTORY_TYPE = new UDAServiceType("ContentDirectory");

    public static final ServiceType SUPPORT_AV_TRANSPORT_TYPE = new UDAServiceType("AVTransport", 1);

    public static final ServiceType SUPPORT_RENDERING_CONTROL_TYPE = new UDAServiceType("RenderingControl");

    // Devices
    public static final DeviceType SUPPORT_MEDIA_RENDERER_TYPE = new UDADeviceType("MediaRenderer", 1);

    public static final DeviceType SUPPORT_MEDIA_SERVER_TYPE = new UDADeviceType("MediaServer", 1);

}
