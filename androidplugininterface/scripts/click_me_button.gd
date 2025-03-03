extends Button

var plugin: Object

func _ready():
	if Engine.has_singleton("MyGodotPlugin"):
		plugin = Engine.get_singleton("MyGodotPlugin")
		if plugin != null:
			print("Plugin successfully detected")
			
			plugin.connect("my_godot_plugin_signal", _on_signal_triggered)
			
			pressed.connect(_on_button_pressed)

func _on_button_pressed():
	if plugin != null:
		plugin.showToastInAndroid("Hello from Godot.")
		
		var data = plugin.getDataFromAndroid()

		print("ClickMeButton.Pressed: data = ", data)

func _on_signal_triggered(message_from_android: String):
	print("ClickMeButton.onSignalTriggered: messageFromAndroid = ", message_from_android)
