![Logo](https://jigoku.io/img/arma_spotify.png)

# ARMASpotify
A simple ARMA Script extension to control spotify from ArmA 3.


A built DLL file can be downloaded [here](https://jigoku.io/up/ARMASpotify.dll)


#Usage:

* Create a @ARMASpotify in your Arma3 directory and put the DLL file there
* Disable BattleEye (I've not looked at the bis keys procedure yet)
* Start spotify
* Start ArmA with -mod=@ARMASpotify
* Call the extension using:
```
"ARMASpotify" callExtension "COMMAND";
```

where commands can be any of the following:
* playpause
* stop
* next
* previous
* mute
* volume_up
* volume_down


No command for selecting a song/album yet, working on it.


#Use it for what?
For missions where you want specific music: create a playlist and ask any players joining your mission to click the first song and pause it. Then let your scripts/triggers walk through the playlist.


* Create hotkeys to control spotify maybe?
* Send a playpause command when entering/exiting a vehicle?


#TODO
* create a 'play:[spotify_album/song_id]' command
* create a 'song_info' command (get current playing song/album, time played etc)
* create a 'status' command (playing or not, shuffle enabled etc)
* Maybe create a linux/mac port. Linux would have a lot functionality (spotify DBUS interface)


Based on code from this tutorial: [Write An ARMA Extension In C#/.NET](http://maca134.co.uk/tutorial/write-an-arma-extension-in-c-sharp-dot-net/)


License: GNU GPLv2
