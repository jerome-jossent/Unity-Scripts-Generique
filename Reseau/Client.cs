using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class Client : MonoBehaviour {
    public int port = 1234;
    public string server = "127.0.0.1";
    public Text index_debug;
    public Text debug_receive;
    public Text debug_send;
    public int index = -99;

    TcpClient client;
    bool running = false;
    string data = "";
    string position_precedente;
    string received_message = "";
    bool otherdatatosend;
    string data2;

    public static Dictionary<int, Player> players;

    void Start () {        
        new System.Threading.Thread(() => {CLIENT_GO(port, server); }).Start();
    }

    private void CLIENT_GO(int port, string server)
    {
        //---create a TCPClient object at the IP and port no.---
        TcpClient client = new TcpClient(server, port);
        print("Server_Connected");

        otherdatatosend = true;
        data2 = "IX";

        running = true;
        while (running)
        {
            #region Client : send data to server
            NetworkStream nwStream = client.GetStream();
            if (otherdatatosend)
            {
                data = data2;
                otherdatatosend = false;
            }

            byte[] bytesToSend = ASCIIEncoding.ASCII.GetBytes(data);
            nwStream.Write(bytesToSend, 0, bytesToSend.Length);
            #endregion

            #region Client : wait then read data from server
            byte[] bytesToRead = new byte[client.ReceiveBufferSize];
            int bytesRead = nwStream.Read(bytesToRead, 0, client.ReceiveBufferSize);
            string message_recu = Encoding.ASCII.GetString(bytesToRead, 0, bytesRead);

            if (message_recu != "RAS")            
                received_message = message_recu;            
            #endregion
        }
        client.Close();

        print("STOPPED");
    }

    private void FixedUpdate()
    {
        index_debug.text = index.ToString();
        debug_receive.text = received_message;
        debug_send.text = data;

        if (received_message == "")
        {
            string position = string.Format("PY|{0}\t{1}\t{2}|{3}\t{4}\t{5}|{6}\t{7}\t{8}",
                gameObject.transform.position.x,
                gameObject.transform.position.y,
                gameObject.transform.position.z,
                gameObject.transform.rotation.x,
                gameObject.transform.rotation.y,
                gameObject.transform.rotation.z,
                gameObject.transform.lossyScale.x,
                gameObject.transform.lossyScale.y,
                gameObject.transform.lossyScale.z);

            if (position == position_precedente)
                data = "00|";
            else
            {
                //Debug.Log(position + "    " + position_precedente);
                data = position;
                position_precedente = position;
            }
            return;
        }

        //https://medium.com/@ashdeepupadhyay/get-object-hierarchy-from-unity-scene-d64f9a96e223
        print(received_message);
        string[] decodage = received_message.Split('!');
        string[] suite;
        string go_nom;
        string script_nom; MonoBehaviour script;

        switch (decodage[0])
        {
            case "IX": // set index du client/joueur
                index = Convert.ToInt32(decodage[1]);
                break;

            case "GO": // activer/désactiver un GAMEOBJECT
                bool State = decodage[2]=="True"?true:false;
                GetDicOfAllGameObjectsInHierarchy.allGOs[decodage[1]].SetActive(State);
                break;

            case "SC": // activer/désactiver un SCRIPT
                suite = decodage[1].Split(';');
                go_nom = suite[0];
                script_nom = suite[1];
                script = (MonoBehaviour)GetDicOfAllGameObjectsInHierarchy.allGOs[go_nom].GetComponent(script_nom);
                if (script != null)
                    script.enabled = !script.enabled;
                else
                {
                    otherdatatosend = true;
                    data2 = "Pas de script attaché à : " + go_nom;
                }
                break;

            case "SV": // modifier la valeur d'une VARIABLE (public static) d'un script
                suite = decodage[1].Split(';');
                go_nom = suite[0];
                script_nom = suite[1];
                script = (MonoBehaviour)GetDicOfAllGameObjectsInHierarchy.allGOs[go_nom].GetComponent(script_nom);

                string[] variable_assignement = suite[2].Split('=');
                string variable_nom = variable_assignement[0];
                float variable_valeur = (float)Convert.ToDouble(variable_assignement[1]);

                script.GetType().GetField(variable_nom).SetValue(script, variable_valeur);
                break;

            case "GS": // renvoit la liste des gameobjects
                data2 = "GS|\r\n";
                bool first = true;
                foreach (string clef in GetDicOfAllGameObjectsInHierarchy.allGOs.Keys)
                {
                    if (first)
                        first = false;
                    else
                        data2 += "\r\n";

                    data2 += clef;
                }
                otherdatatosend = true;
                break;

            case "PL": //liste des joueurs avec les infos
                suite = decodage[1].Split(new char[] { '#' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string joueur in suite)
                {
                    Debug.Log(joueur);
                    continue;//debug


                    //1;127.0.0.1;240,248,255;0	1,48	0 | 0	0	0 | 1	1	1 | 
                    string[] joueur_infos = joueur.Split(';');
                    int j_index = Convert.ToInt32(joueur_infos[0]);

                    // est-ce moi ?
                    if (j_index == index) continue;

                    // est-il déjà dans mon monde ?
                    if (!players.ContainsKey(j_index))
                    {


                    }


                    string j_IP = joueur_infos[1];
                    string[] j_couleur_RGB = joueur_infos[2].Split(',');

                    string[] j_transform = joueur_infos[3].Split('|');

                }

                break;
        }
        received_message = "";
    }

    void print(string text)
    {
        Debug.Log(text);

        //if (tmp == null) return;

        //try
        //{
        //    string txt = text + "\r\n" + tmp.text;
        //    if (txt.Length > 250)
        //        txt = txt.Substring(0, 250);
        //    tmp.text = txt;
        //}
        //catch (Exception ex)
        //{
        //    Debug.Log(ex.Message);
        //}
    }
}

public class Player
{

    public Material couleur;
    public Transform position;
    public int index;
    public string name;
}