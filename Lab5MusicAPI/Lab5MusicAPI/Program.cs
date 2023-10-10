using MetaBrainz.MusicBrainz.Interfaces.Entities;
using Id3;
using Microsoft.VisualBasic;
using System.Net;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Media;
using System.IO;

namespace Lab5MusicAPI
{
    public class Program
    {
        const string useragent = "Lab5MusicAPI/1.0 (kyleb4415@gmail.com)";
        static async Task Main(string[] args)
        {
            string selection = "0";
            Console.WriteLine(new String('-', 80));
            Console.WriteLine("Welcome to Lab5 Music API Ver 1.0");
            Console.WriteLine(new String('-', 80));
            Console.WriteLine("\n\n\n\n\nPress enter to continue.");
            Console.ReadLine();
            Console.Clear();

            while (selection != "-1")
            {
                switch (selection)
                {
                    case "0":
                        Console.Clear();
                        Console.WriteLine(new String('-', 80));
                        Console.WriteLine("Menu");
                        Console.WriteLine(new String('-', 80));
                        Console.WriteLine("1: Search for Artist");
                        Console.WriteLine("2: Search for Song");
                        Console.WriteLine("3: Search for Event");
                        Console.WriteLine("4: Play .WAV file");
                        Console.Write("\n\n\n\n\nProvide a selection or -1 to exit: ");
                        selection = Console.ReadLine();

                        break;
                    case "1":
                        Console.Clear();
                        Console.Write("Input the artist you wish to search: ");
                        await ArtistCall(Console.ReadLine());

                        Console.WriteLine("Press enter to exit.");
                        Console.ReadLine();
                        selection = "0";
                        break;

                    case "2":
                        Console.Clear();
                        Console.Write("Input a song you wish to search: ");
                        FindSong(Console.ReadLine());
                        Console.ReadLine();
                        selection = "0";
                        break;

                    case "3":
                        Console.Clear();
                        Console.Write("Enter an event you wish to search: ");
                        EventCall(Console.ReadLine());
                        Console.WriteLine("Press enter to return to the menu.");
                        Console.ReadLine();
                        selection = "0";
                        break;
                    case "4":
                        Console.Clear();
                        PlayMusic();
                        Console.ReadLine();
                        selection = "0";
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Please enter a valid input.");
                        Console.WriteLine("\n\n\n\n\nPress enter to continue.");
                        Console.ReadLine();
                        selection = "0";
                        break;
                }
            }
            Console.WriteLine("Thanks for using this program! Press enter to exit.");
            Console.ReadLine();
        }

        public static async Task ArtistCall(string artistName)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.UserAgent.ParseAdd(useragent);
                HttpResponseMessage response = await client.GetAsync($"https://musicbrainz.org/ws/2/artist?query={artistName}&limit=2&fmt=json");

                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    var options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
                    var artist = JsonSerializer.Deserialize<GetArtist>(json, options);
                    for (int i = 0; i < artist.Artists.Count; i++)
                    {
                        Console.WriteLine(artist.Artists[i].ToString());
                    }
                }
                else
                {
                    Console.WriteLine("Search unsuccessful.");
                }
            }
        }
        public static async Task EventCall(string EventName)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.UserAgent.ParseAdd(useragent);
                HttpResponseMessage response = await client.GetAsync($"https://musicbrainz.org/ws/2/event?query={EventName}&limit=2&fmt=json");
                response.EnsureSuccessStatusCode();

                string json = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
                var eventStuff = JsonSerializer.Deserialize<GetEvent>(json, options);

                Console.WriteLine($"Event Information: {eventStuff.ToString()}");
                for (int i = 0; i < eventStuff.Events.Count; i++)
                {
                    Console.WriteLine(eventStuff.Events[i].ToString());
                }
            }
        }

        public static async Task FindSong(string song)
        {
            using (var client = new HttpClient())
            {
                song = Regex.Replace(song, " ", "_");

                client.DefaultRequestHeaders.UserAgent.ParseAdd(useragent);
                HttpResponseMessage response = await client.GetAsync($"https://musicbrainz.org/ws/2/recording?inc=artist-credits&query={song}&limit=1&fmt=json");
                response.EnsureSuccessStatusCode();


                string json = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
                GetRecording recordingStuff = JsonSerializer.Deserialize<GetRecording>(json, options);
                Console.WriteLine(recordingStuff.ToString());
                Console.ReadLine();

            }
        }

        //begin playmusic
        public static async Task PlayMusic()
        {
            //Declarations, fileselection/fileselection as int are from automatic selection from music folder. Validfile is a check on whether the index of the file exists for
            //file selection. filecounter is used to visually index files for the user to select.
            string fileSelection = string.Empty;
            int fileSelectionAsInt;
            bool validFile = false;
            int fileCounter = 1;


            string musicFolder = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.Parent.Parent.Parent.ToString() + "\\Music";

            Console.WriteLine("Please provide a filepath to a .wav file, or press enter to automatically use your music folder: ");
            string filePath = Console.ReadLine();
            if(filePath != string.Empty)
            {

                try
                {
                    Directory.GetFiles(filePath, "*.wav");
                    PlayMusicFile(filePath);
                    
                }
                catch
                {
                    Console.WriteLine("Invalid filepath. Please try again.");
                    Console.WriteLine("Press enter to go back to the menu.");
                    
                }

            }

            //begin optional selection from default system music folder if a filepath is not provided
            if (filePath == string.Empty)
            {
                filePath = musicFolder;
                Console.WriteLine("Choose a file from the music folder: ");
                List<string> fileNames = new List<string>();
                var filesLiteral = Directory.GetFiles(musicFolder, "*.wav");
                foreach (var f in filesLiteral)
                {
                    fileNames.Add(f.ToString());
                }
                while (validFile == false)
                {
                    foreach (var f in fileNames)
                    {
                        Console.WriteLine($"{fileCounter++}: {f}");
                    }

                    Console.Write("Choose one of these options by typing the number here: ");

                    while(!validFile)
                    {
                        Console.WriteLine("Please enter a valid file number.");
                        Console.Write("Selection: ");
                        Int32.TryParse(Console.ReadLine(), out fileSelectionAsInt);
                        if(fileSelectionAsInt < fileNames.Count + 1 && fileSelectionAsInt > 0)
                        {
                            filePath = fileNames[fileSelectionAsInt - 1];
                            validFile = true;
                        }
                    }
                }

            }
            PlayMusicFile(filePath);
        }
        //end playmusic

        public static string GetLastPartOfFilepath(string filepath)
        {
            string[] filepathSplit = filepath.Split('\\');
            string lastPart = filepathSplit[filepathSplit.Length - 1];
            lastPart = Regex.Replace(lastPart, ".wav", "");
            return lastPart;
        }

        public static async Task PlayMusicFile(string filePath)
        {
            SoundPlayer player = new SoundPlayer();
            player.SoundLocation = filePath;
            player.Play();

            Console.WriteLine("Song Info: ");
            //begin api calls to get song info from .wav

            var client = new HttpClient();
            string song = Regex.Replace(filePath, " ", "_");
            Console.WriteLine(song);

            Console.WriteLine(GetLastPartOfFilepath(filePath));
            client.DefaultRequestHeaders.UserAgent.ParseAdd(useragent);
            HttpResponseMessage response = await client.GetAsync($"https://musicbrainz.org/ws/2/recording?inc=artist-credits&query={GetLastPartOfFilepath(filePath)}&limit=1&fmt=json");
            response.EnsureSuccessStatusCode();

            string json = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
            var artistStuff = JsonSerializer.Deserialize<GetRecording>(json, options);
            Console.WriteLine($"Track Info: {artistStuff.ToString()}");
            Console.WriteLine("Press enter to stop and enter again go back to the menu.");
            Console.ReadLine();
            player.Stop();
            Console.ReadLine();
        }
    }
}