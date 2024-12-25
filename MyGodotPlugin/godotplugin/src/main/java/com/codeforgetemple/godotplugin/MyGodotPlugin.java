package com.codeforgetemple.godotplugin;

import android.os.Handler;
import android.os.Looper;
import android.widget.Toast;

import org.godotengine.godot.Godot;
import org.godotengine.godot.plugin.GodotPlugin;
import org.godotengine.godot.plugin.SignalInfo;
import org.godotengine.godot.plugin.UsedByGodot;

import java.util.Collections;
import java.util.HashSet;
import java.util.Set;

public class MyGodotPlugin extends GodotPlugin {
    /**
     * Base constructor passing a {@link Godot} instance through which the plugin can access Godot's
     * APIs and lifecycle events.
     *
     * @param godot
     */
    public MyGodotPlugin(Godot godot) {
        super(godot);

        delayedSignalTrigger();
    }

    @Override
    public String getPluginName() {
        return BuildConfig.GODOT_PLUGIN_NAME;
    }

    @Override
    public Set<SignalInfo> getPluginSignals() {
        Set<SignalInfo> signals = new HashSet<>();

        signals.add(new SignalInfo("my_godot_plugin_signal", String.class));

        return signals;
    }

    private void delayedSignalTrigger() {
        new Handler(Looper.getMainLooper()).postDelayed(()->{
            emitSignal("my_godot_plugin_signal", "Hello from Android with Godot Signals!");
        }, 15000);
    }

    @UsedByGodot
    public void showToastInAndroid(String godotMessagePrefix) {
        StringBuilder message = new StringBuilder();

        message.append(godotMessagePrefix).append(" ").append("Hello from Android!");

        runOnUiThread(()->{
            Toast.makeText(getActivity(), message.toString(), Toast.LENGTH_LONG).show();
        });
    }

    @UsedByGodot
    public String getDataFromAndroid() {
        return "This is a string from Android";
    }

}
