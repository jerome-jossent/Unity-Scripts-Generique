using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Permet d'afficher à l'écran (tête haute) du texte avec une durée d'affichage paramétrable, une couleur, une taille de caractère.
/// Si la durée est négative alors le message sera toujours conservé
/// 
/// A attacher à un GameObject
/// Y faire référence (avec un script d'un autre GameObject) : 
///     [SerializeField] PrintToGUI PRINT; 
/// possibilité d'activer/désactiver cette fonctionnalité en affectant dans l'inspector une touche au paramètre 
///     ToucheDisplayGUI
///     
/// EXEMPLE 1 : 
///     PRINT._DisplayText("Your internal IP is " + local_IP, new Color(0, 0.8f, 0.1f, 1), 15, 2);
/// 
/// EXEMPLE 2 : 
///     [SerializeField] PrintToGUI PRINT;
///     private void Start()
///     {
///         PRINT._DisplayText(gameObject.name + "p", transform.position, new Color(1, 0, 0), 20);
///         PRINT._DisplayText(gameObject.name + "r", transform.rotation, new Color(1, 1, 0), 20);
///     }
///     void Update()
///     {
///         PRINT._DisplayText(gameObject.name + "p", transform.position);
///         PRINT._DisplayText(gameObject.name + "r", transform.rotation);
///     } 
/// </summary>
public class PrintToGUI : MonoBehaviour
{
    #region Static & Singleton
    static PrintToGUI _singleton;

    public static void __DisplayText(string texte,
                             Color? couleurRGB = null,
                             float duree_avant_fade_sec = 0,
                             float duree_fade_sec = 0,
                             int fontsize = 0)
    {
        _singleton._DisplayText(texte, couleurRGB, duree_avant_fade_sec, duree_fade_sec, fontsize);
    }

    internal static void __ClearScreen()
    {
        _singleton.messages.Clear();
        _singleton.indexToRemove.Clear();
    }
    #endregion

    #region PARAMETRES
    [SerializeField] KeyCode ToucheDisplayGUI;
    [SerializeField] string helloMessage;
    [SerializeField] Color defaultColor = Color.white;
    [SerializeField] int defaultFontSize = 20;
    [SerializeField] float defaultDuree_avant_fade_sec = 20;
    [SerializeField] float defaultDuree_fade_sec = 2;
    #endregion

    #region VARIABLES INTERNES
    bool displayGUI;
    Dictionary<int, Message> messages = new Dictionary<int, Message>();
    Dictionary<string, int> clefs = new Dictionary<string, int>();
    int compteur = 0;
    List<int> indexToRemove = new List<int>();
    #endregion
    
    /// <summary>
    /// TYPE 1 : message fixe (éphémère ou permanent)
    /// </summary>
    /// <param name="texte">message à afficher</param>
    /// <param name="couleurRGB">null pour couleur par défaut</param>
    /// <param name="duree_avant_fade_sec">si 0 alors message permanent</param>
    /// <param name="duree_fade_sec">si positif alors effet de fondu</param>
    /// <param name="fontsize">taille de la police d'écriture, si 0 : taille par défaut</param>
    public void _DisplayText(string texte,
                             Color? couleurRGB = null,
                             float duree_avant_fade_sec = 0,
                             float duree_fade_sec = 0,
                             int fontsize = 0)
    {
        int newclef = compteur--;
        if (duree_avant_fade_sec == 0) duree_avant_fade_sec = defaultDuree_avant_fade_sec;
        if (duree_fade_sec == 0) duree_fade_sec = defaultDuree_fade_sec;
        if (fontsize == 0) fontsize = defaultFontSize;

        messages.Add(newclef, new Message(texte, newclef, GetColor(couleurRGB), duree_avant_fade_sec, duree_fade_sec, fontsize));
    }
    
    #region TYPE 2 : message dynamique
    internal void _DisplayText(string clef, Transform transform,    Color? couleurRGB = null, int fontsize = 0)
    {
        string text = transform.position.ToString() + " | " +
                      transform.rotation.ToString() + " | " +
                      transform.localScale.ToString();
        _DisplayText(clef, text, couleurRGB, fontsize);
    }
    internal void _DisplayText(string clef, Vector3 v3,             Color? couleurRGB = null, int fontsize = 0)
    {
        string text = "x:" + v3.x.ToString() + "\ty:" + v3.y.ToString() + "\tz:" + v3.z.ToString();
        _DisplayText(clef, text, couleurRGB, fontsize);
    }
    internal void _DisplayText(string clef, Quaternion q,           Color? couleurRGB = null, int fontsize = 0)
    {
        string text = "x:" + q.x.ToString() + "\ty:" + q.y.ToString() + "\tz:" + q.z.ToString() + "\tw:" + q.w.ToString();
        _DisplayText(clef, text, couleurRGB, fontsize);
    }
    /// <summary>
    /// TYPE 2 : message dynamique
    /// conseil : appeler une première fois avec les infos de couleur et de taille de police, les fois suivantes
    /// </summary>
    /// <param name="clef">identifiant de la ligne de texte</param>
    /// <param name="texte">texte affiché</param>
    /// <param name="couleurRGB">null pour couleur par défaut</param>
    /// <param name="fontsize">taille de la police d'écriture, si 0 : taille par défaut</param>
    internal void _DisplayText(string clef, string texte,           Color? couleurRGB = null, int fontsize = 0)
    {
        if (!clefs.ContainsKey(clef))
        {
            int newclef = compteur--;
            clefs.Add(clef, newclef);
            if (fontsize == 0) fontsize = defaultFontSize;
            messages.Add(newclef, new Message(texte, newclef, GetColor(couleurRGB), -1, 0, fontsize));
        }

        //update texte
        messages[clefs[clef]].texte = texte;
    }
    #endregion

    #region Méthodes annexes
    Color GetColor(Color? couleurRGB) { return (couleurRGB == null) ? defaultColor : (Color)couleurRGB; }
    
    //public void _createrandommessage()
    //{
    //    string txt = Random.value.ToString();
    //    Color col = Random.ColorHSV(0, 1, 0, 1, 0, 1, 1, 1);
    //    float d = Random.Range(2, 5);
    //    float f = Random.Range(0, 3);
    //    _DisplayText(txt, col, d, f);
    //}
    #endregion

    #region Méthodes Unity
    //initialisation et affichage des messages
    private void Awake()
    {
        if (_singleton == null)
            _singleton = this;

        displayGUI = true;

        if (helloMessage != "")
            _DisplayText(helloMessage);

        if (displayGUI && ToucheDisplayGUI != KeyCode.None)
            _DisplayText("Press " + ToucheDisplayGUI.ToString() + " to hide/show GUI");
    }

    //activation/désactivation de l'affichage tête haute
    void Update()
    {
        if (Input.GetKeyDown(ToucheDisplayGUI))
            displayGUI = !displayGUI;
    }

    void FixedUpdate()
    {
        if (!displayGUI) return;

        foreach (Message m in messages.Values)
            m.update(indexToRemove);

        // supprimé les messages qui ne sont plus affichés
        while (indexToRemove.Count > 0)
        {
            messages.Remove(indexToRemove[indexToRemove.Count - 1]);
            indexToRemove.RemoveAt(indexToRemove.Count - 1);
        }
    }

    //affichage tête haute de tous les messages
    void OnGUI()
    {
        if (displayGUI) 
            foreach (Message m in messages.Values)
                GUILayout.Label(m.texte, m.style);        
    }
    #endregion

    class Message
    {
        public string texte;
        int clef;

        float alpha;
        float alphaDecreaseStep;
        Color couleur;
        public GUIStyle style = new GUIStyle();// UnityEditor.EditorStyles.label);

        float time;
        float time_display;
        float time_display_endfade;

        bool permanent;

        // init
        public Message(string texte, int clef, Color couleurRGB, float duree_avant_fade_sec, float duree_fade_sec, int fontsize)
        {
            this.texte = texte;
            this.clef = clef;

            couleur = couleurRGB;
            style.normal.textColor = couleur;
            style.fontSize = fontsize;

            time = Time.time;
            time_display = time + duree_avant_fade_sec;
            time_display_endfade = this.time_display + duree_fade_sec;

            permanent = (duree_avant_fade_sec < 0);

            alpha = couleur.a;
            if (duree_fade_sec > 0)
                alphaDecreaseStep = Time.fixedDeltaTime / duree_fade_sec;
            else
                alphaDecreaseStep = 1;
        }

        public void update(List<int> AVirer)
        {
            if (permanent) return;

            // fin
            if (Time.time > time_display_endfade)
            {
                AVirer.Add(clef);
                return;
            }

            // fade
            if (Time.time > time_display)
            {
                alpha -= alphaDecreaseStep;
                couleur = new Color(couleur.r, couleur.g, couleur.b, alpha);
                style.normal.textColor = couleur;
            }
        }
    }
}