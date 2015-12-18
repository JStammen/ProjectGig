package gigapi;

import org.fourthline.cling.support.model.DIDLContent;
import org.fourthline.cling.support.model.container.Container;
import org.fourthline.cling.support.model.item.Item;

import java.util.ArrayList;

/**
 * Created by Kees Bank on 6/19/2014.
 */
public class Directory {

    public ArrayList<Track> tracks = new ArrayList<>();
    public ArrayList<Container> childrenDirectories = new ArrayList<>();
    public String parentDirectory;


    public Directory(DIDLContent didlContent){
        parentDirectory = didlContent.getFirstContainer().getParentID();

        for(Container containter :didlContent.getContainers()){
             childrenDirectories.add(containter);
        }

        for(Item item : didlContent.getItems()){
            tracks.add((Track)item);
        }
    }




}
