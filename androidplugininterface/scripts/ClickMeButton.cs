using Godot;
using System;

public partial class ClickMeButton : Button
{
	GodotObject plugin;

	public override void _Ready()
	{
		if (Engine.HasSingleton("MyGodotPlugin"))
		{
			plugin = Engine.GetSingleton("MyGodotPlugin");

			if (plugin != null)
			{
				GD.Print("Plugin successfully detected");

				plugin.Connect("my_godot_plugin_signal", new Callable(this, nameof(onSignalTriggered)));

				Pressed += () =>
				{
					plugin.Call("showToastInAndroid", "Hello from Godot.");

					string data = (string)plugin.Call("getDataFromAndroid");

					GD.Print("ClickMeButton.Pressed: data = " + data);
				};
			}

		}
	}

	private void onSignalTriggered(string messageFromAndroid)
	{
		GD.Print("ClickMeButton.onSignalTriggered: messageFromAndroid = " + messageFromAndroid);
	}

}
