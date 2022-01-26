using UnityEngine;

public class GetIP : MonoBehaviour
{
    public string IP_local = "";
    public string IP_external = "";
    [SerializeField] Color GUICoulor = Color.white;

    [Tooltip("0 Infinite | <0 no GUI")]
    [SerializeField] float displayed_Time = 60;
    [SerializeField] Vector2? GUI_Position = null;
    Vector2 tailleLabel = new Vector2(300, 30);
    void Start()
    {
        IP_external = Get_IP_ByCode.Get_External_IP();
        IP_local = Get_IP_ByCode.Get_Local_IP();
        if (GUI_Position == null)
            GUI_Position = new Vector2(Screen.width / 2, Screen.height / 2) - new Vector2(100, 40);
    }

    private void OnGUI()
    {
		if (displayed_Time <0) return;
		
        GUI.contentColor = GUICoulor;
		if(displayed_Time > 0)
		{
			if (Time.time > displayed_Time) return;
			int tempsrestant = (int)(displayed_Time - Time.time);
			GUI.Label(new Rect((Vector2)GUI_Position + new Vector2(0, 60), tailleLabel), "Info cachées dans : " + tempsrestant);
		}
        GUI.Label(new Rect((Vector2)GUI_Position, tailleLabel), "IP externe\t: " + IP_external);
		GUI.Label(new Rect((Vector2)GUI_Position + new Vector2(0, 30), tailleLabel), "IP locale\t: " + IP_local);
    }
}

public static class Get_IP_ByCode
{
    public static string Get_External_IP()
    {
        string uri = "https://api.ipify.org";
        System.Net.WebRequest request = System.Net.WebRequest.Create(uri);
        System.Net.HttpWebResponse response = (System.Net.HttpWebResponse)request.GetResponse();
        System.IO.Stream dataStream = response.GetResponseStream();
        System.IO.StreamReader reader = new System.IO.StreamReader(dataStream);
        string ip = reader.ReadToEnd();
        reader.Close();
        return ip;
    }

    public static string Get_Local_IP()
    {
        System.Net.IPHostEntry host;
        host = System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName());
        foreach (System.Net.IPAddress ip in host.AddressList)
            if (ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                return ip.ToString();

        return "";
    }
}