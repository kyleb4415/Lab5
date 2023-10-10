# Lab5
Lab 5 Implementing Your Plan

# Lab5 Ver1.0
## 10/8/2023 2:00pm
Ran into some issues connecting to the API. Had to create a 'meaningful user-agent header' to connect to the database. After some searching online,
I was able to create one.
## 10/8/2023 8:00pm
Was able to successfully create classes mirroring artists and events. Was able to deserialize into objects, but noticed that the json string contained multiple 
different artists. Was unable to create a list of artists from the multiple json objects, will try later.
## 10/9/2023 10:09am
Was able to create lists of artists and events from the json. Unfortunately, I realized that the api doesn't have search functionality for genres yet, so I won't be able to implement them exactly as my plan prescribed.
## 10/9/2023 9:35pm
Created search functions for artist, event, and song. Attempting to create an .wav file player using SoundPlayer from System.Media. Wanting to take wav metadata and query on MusicBrainz.
## 10/10/2023 10:55am
Implemented four functions within the program; get event by search, get artist by search, and get recording by search. There's also functionality to play a wav file through the console by either providing a filepath or by playing a file out of the music folder of the pc. This function also makes an API call that provides some information about the recording by querying the name of the file in the API, so this will only work if the .wav file is named in an appropriate fashion.
