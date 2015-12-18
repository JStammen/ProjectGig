package gigapi;

import android.app.Activity;
import android.widget.ArrayAdapter;
import org.fourthline.cling.model.meta.Device;
import org.fourthline.cling.support.model.item.Item;

/**
 * Created by Kees Bank on 6/19/2014.
 * Primary interface of the GIG API
 */
public interface IController {

    public void searchDevices();

    public void play(Device renderer, Item track);

    public void pause(Device renderer);

    public void resume(Device renderer);

    public void previous(Device renderer);

    public void next(Device renderer);

    public void seek(Device renderer,  long progress);

    public void browseFolder(Device server, Activity activity, String currentdir, ArrayAdapter arrayAdapter);

    public void browseRoot(Device server, Activity activity, String currentdir, ArrayAdapter arrayAdapter);

    public void mute(Device renderer);

}
