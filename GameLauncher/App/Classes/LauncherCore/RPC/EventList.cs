using GameLauncher.App.Classes.LauncherCore.FileReadWrite;
using GameLauncher.App.Classes.LauncherCore.Support;
using Newtonsoft.Json;
using System;
using GameLauncher.App.Classes.LauncherCore.Logger;

namespace GameLauncher.App.Classes.LauncherCore.RPC
{
    class EventsList
    {
        public static String remoteEventsList = String.Empty;

        public static string GetEventName(int id)
        {
            /* Let's load the "From Server" version first */
            if (remoteEventsList != String.Empty)
            {
                dynamic dynJson = JsonConvert.DeserializeObject(Strings.Encode(remoteEventsList));

                foreach (var item in dynJson)
                {
                    if (item.id == id)
                    {
                        return item.trackname;
                    }
                }
            }

            /* If we don't have a Server version, load "default" version */
            if (remoteEventsList == String.Empty)
            {
                dynamic dynJson = JsonConvert.DeserializeObject(Strings.Encode(
                    ExtractResource.AsString("GameLauncher.App.Classes.LauncherCore.RPC.JSON.events.json")));

                foreach (var item in dynJson)
                {
                    if (item.id == id)
                    {
                        return item.trackname;
                    }
                }
            }

            /* And if it's not found, do this instead */
            return "EVENT:" + id;
        }

        public static string GetEventType(int id)
        {
            /* Let's load the "From Server" version first */
            if (remoteEventsList != String.Empty)
            {
                dynamic dynJson = JsonConvert.DeserializeObject(Strings.Encode(remoteEventsList));

                foreach (var item in dynJson)
                {
                    if (item.id == id)
                    {
                        return item.type;
                    }
                }
            }

            /* If we don't have a Server version, load "default" version */
            if (remoteEventsList != String.Empty)
            {
                dynamic dynJson = JsonConvert.DeserializeObject(Strings.Encode(
                    ExtractResource.AsString("GameLauncher.App.Classes.LauncherCore.RPC.JSON.events.json")));

                foreach (var item in dynJson)
                {
                    if (item.id == id)
                    {
                        return item.type;
                    }
                }
            }

            /* And if it's not found, do this instead */
            return "gamemode_freeroam";
        }

        public static string GetEventTypeString(string gamemode_type)
        {
            switch (gamemode_type)
            {
                case "gamemode_circuit":
                    return "สนามเซอร์กิต";
                case "gamemode_drag":
                    return "สนามแดร็ก";
                case "gamemode_meetingplace":
                    return "จุดนัดพบ";
                case "gamemode_pursuit_mp":
                    return "หนีการจับกุมแบบทีม";
                case "gamemode_pursuit_sp":
                    return "หลบหนีการจับกุม";
                case "gamemode_sprint":
                    return "สนามสปรินต์";
                case "gamemode_treasure":
                    return "ล่าสมบัติ";
                case "gamemode_freeroam":
                    return "Free Roam";
            }

            return "Free Roam";
        }
    }
}
