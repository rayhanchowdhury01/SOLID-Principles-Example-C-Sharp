
/*Interface Segregation Principle (ISP) :

    This C# code illustrates the Interface Segregation Principle 
    by designing a set of interfaces representing various electronic device functionalities. 
    The IDevice interface provides basic power-related operations, while specific interfaces:
            IConnectable, 
            IDisplayable, 
            ICamera, 
            IMusicPlayer 
    and they segregate functionalities for internet connectivity, display, camera, and music playback, respectively. 
    The Smartphone, DigitalCamera, MusicPlayer, and SmartTV classes implement only the interfaces relevant to their capabilities, adhering to the ISP. 
    This ensures that each device has access only to the functionalities it requires, promoting a more modular and maintainable codebase.
    */

using System;
using System.Collections.Generic;

namespace ISP
{
    public interface IDevice
    {
        void PowerOn();
        void PowerOff();
    }

    // Interface for devices with internet connectivity
    public interface IConnectable
    {
        void ConnectToInternet();
    }

    // Interface for devices with a display
    public interface IDisplayable
    {
        void Display(string msg);
    }
    // Interface for devices with a camera

    public interface ICamera
    {
        void TakePhoto();
        void RecordVideo();
    }

    // Interface for devices with music playback capabilities
    public interface IMusicPlayer
    {
        void PlayMusic();
        void PauseMusic();
        void StopMusic();
    }

    // Smartphone class implementing multiple interfaces
    public class Smartphone : IDevice, IConnectable, IDisplayable, ICamera, IMusicPlayer
    {
        public void PowerOn() => Console.WriteLine("SmartPhone Powered On....");

        public void PowerOff() => Console.WriteLine("SmartPhone Powered OFF....");

        public void ConnectToInternet() => Console.WriteLine("Connected to the internet.");

        public void Display(string msg) => Console.WriteLine($"Displaying: {msg}");

        public void TakePhoto() => Console.WriteLine("Photo taken.");

        public void RecordVideo() => Console.WriteLine("Video Recorded.");

        public void PlayMusic() => Console.WriteLine("Music playing. .-.");

        public void PauseMusic() => Console.WriteLine("Music Paused !");

        public void StopMusic() => Console.WriteLine("Music Stopped,");
    }

    // DigitalCamera class implementing relevant interfaces
    public class DigitalCamera : IDevice, ICamera, IDisplayable
    {
        public void PowerOn() => Console.WriteLine("Digital camera powered on.");

        public void PowerOff() => Console.WriteLine("Digital camera powered off.");

        public void TakePhoto() => Console.WriteLine("Photo taken.");

        public void RecordVideo() => Console.WriteLine("Digital cameras can't record videos.");

        public void Display(string content) => Console.WriteLine($"Displaying captured image: {content}");
    }

    // MusicPlayer class implementing relevant interfaces
    public class MusicPlayer : IDevice, IMusicPlayer
    {
        public void PowerOn() => Console.WriteLine("Music player powered on.");

        public void PowerOff() => Console.WriteLine("Music player powered off.");

        public void PlayMusic() => Console.WriteLine("Music playing.");

        public void PauseMusic() => Console.WriteLine("Music paused.");

        public void StopMusic() => Console.WriteLine("Music stopped.");
    }

    // SmartTV class implementing relevant interfaces
    public class SmartTV : IDevice, IConnectable, IDisplayable, IMusicPlayer
    {
        public void PowerOn() => Console.WriteLine("Smart TV powered on.");

        public void PowerOff() => Console.WriteLine("Smart TV powered off.");

        public void ConnectToInternet() => Console.WriteLine("Smart TV connected to the internet.");

        public void Display(string content) => Console.WriteLine($"Smart TV displaying: {content}");

        public void PlayMusic() => Console.WriteLine("Smart TV playing background music.");

        public void PauseMusic() => Console.WriteLine("Smart TV music paused.");

        public void StopMusic() => Console.WriteLine("Smart TV music stopped.");
    }

    // Main Program
    public class Test
    {
        public static void Main(string[] args)
        {
            Smartphone SP = new Smartphone();
            DigitalCamera DC = new DigitalCamera();
            MusicPlayer MP = new MusicPlayer();
            SmartTV ST = new SmartTV();

            // Using Smartphone
            Console.WriteLine("Using Smartphone:");
            SP.PowerOn();
            SP.ConnectToInternet();
            SP.Display("Smartphone home screen");
            SP.TakePhoto();
            SP.RecordVideo();
            SP.PlayMusic();
            SP.PauseMusic();
            SP.StopMusic();
            SP.PowerOff();
            Console.WriteLine("\n");

            // Using Digital Camera
            Console.WriteLine("Using Digital Camera:");
            DC.PowerOn();
            DC.TakePhoto();
            DC.RecordVideo();
            DC.Display("Captured image");
            DC.PowerOff();

            Console.WriteLine("\n");

            // Using Music Player
            Console.WriteLine("Using Music Player:");
            MP.PowerOn();
            MP.PlayMusic();
            MP.PauseMusic();
            MP.StopMusic();
            MP.PowerOff();

            Console.WriteLine("\n");

            // Using Smart TV
            Console.WriteLine("Using Smart TV:");
            ST.PowerOn();
            ST.ConnectToInternet();
            ST.Display("Smart TV main menu");
            ST.PlayMusic();
            ST.PauseMusic();
            ST.StopMusic();
            ST.PowerOff();
        }
    }
}