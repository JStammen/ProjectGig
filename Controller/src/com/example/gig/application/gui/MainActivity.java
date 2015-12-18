package com.example.gig.application.gui;

import android.os.Bundle;
import android.support.v4.app.Fragment;
import android.support.v4.app.FragmentStatePagerAdapter;
import android.support.v4.view.ViewPager;
import android.support.v7.app.ActionBarActivity;
import com.example.GIGUPnPController.R;
import org.fourthline.cling.support.model.item.Item;

import java.util.List;


/**
 * Created by Kees Bank on 6/16/2014.
 */
public class MainActivity extends ActionBarActivity {

    private ServerFragment serverFragment;
    private RendererFragment rendererFragment;
    ViewPager mViewPager;

    FragmentStatePagerAdapter fragmentStatePagerAdapter =
            new FragmentStatePagerAdapter(getSupportFragmentManager()) {
                @Override
                public Fragment getItem(int position) {
                    switch(position) {
                        case 0:
                            return serverFragment;
                        case 1:
                            return rendererFragment;
                        default:
                            return null;
                    }
                }

                @Override
                public int getCount() {
                    return 2;
                }
            };





    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        final android.support.v7.app.ActionBar actionBar = getSupportActionBar();


        actionBar.setNavigationMode(android.support.v7.app.ActionBar.NAVIGATION_MODE_TABS);

        setContentView(R.layout.activity_main);

        mViewPager = (ViewPager) findViewById(R.id.pager);
        mViewPager.setAdapter(fragmentStatePagerAdapter);
        mViewPager.setOnPageChangeListener(new ViewPager.SimpleOnPageChangeListener() {
            @Override
            public void onPageSelected(int position) {
                actionBar.setSelectedNavigationItem(position);
            }
        });

        android.support.v7.app.ActionBar.TabListener tabListener = new android.support.v7.app.ActionBar.TabListener() {
            @Override
            public void onTabSelected(android.support.v7.app.ActionBar.Tab tab, android.support.v4.app.FragmentTransaction fragmentTransaction) {
                mViewPager.setCurrentItem(tab.getPosition());
            }

            @Override
            public void onTabUnselected(android.support.v7.app.ActionBar.Tab tab, android.support.v4.app.FragmentTransaction fragmentTransaction) {

            }

            @Override
            public void onTabReselected(android.support.v7.app.ActionBar.Tab tab, android.support.v4.app.FragmentTransaction fragmentTransaction) {

            }
        };




        // Adding Tabs
        actionBar.addTab(actionBar.newTab().setText(R.string.tab1).setTabListener(tabListener));
        actionBar.addTab(actionBar.newTab().setText(R.string.tab2).setTabListener(tabListener));

        serverFragment = new ServerFragment();
        rendererFragment = new RendererFragment();




    }

    public void play(List<Item> playlist, int start){
        mViewPager.setCurrentItem(1);
        rendererFragment.play(playlist, start);

    }
}