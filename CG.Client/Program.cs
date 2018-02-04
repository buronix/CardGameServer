using CG.Client.Adapters;
using CG.Models;
using CG.ServiceModels.Game;
using ServiceStack.Text;
using System;
using System.Net;

namespace CG.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            GetGamesResponse gamesResponse = null;
            GetGameResponse gameResponse = null;

            AbstractAdapter Adapter = null;
            string hostUri = "NotValidHostUri";
            
            try
            {
                Adapter = new JsonServiceAdapter(hostUri);
                gamesResponse = Adapter.Client.Get(new GetGames());
                gamesResponse.PrintDump();
            }
            catch (Exception e)
            {
                e.PrintDump();
            }

            hostUri = "http://localhost:8085/";

            try
            {
                Adapter = new JsonServiceAdapter(hostUri);
                gamesResponse = Adapter.Client.Get(new GetGames());
                gamesResponse.PrintDump();
            }
            catch (WebException we)
            {
                we.PrintDump();
            }
            catch (Exception e)
            {
                e.PrintDump();
            }
            
            try
            {
                Adapter = new ProtobufAdapter(hostUri);
                gamesResponse = Adapter.Client.Get(new GetGames());
                gamesResponse.PrintDump();

                gameResponse = Adapter.Client.Get(new GetGame { Id = 1 });
                gameResponse.PrintDump();
            }
            catch (WebException we)
            {
                we.PrintDump();
            }
            catch (Exception e)
            {
                e.PrintDump();
            }

            try
            {
                Adapter = new ProtobufAdapter(hostUri);
                gameResponse = Adapter.Client.Get(new GetGame {});
                gameResponse.PrintDump();
            }
            catch (WebException we)
            {
                we.PrintDump();
            }
            catch (Exception e)
            {
                e.PrintDump();
            }

            Console.ReadKey(false);

        }
    }
}
