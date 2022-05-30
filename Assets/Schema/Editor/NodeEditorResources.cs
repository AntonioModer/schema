using UnityEditor;
using UnityEngine;

internal static class Styles
{
    //Colors
    public static Color windowBackground => EditorGUIUtility.isProSkin ? DarkBackgroundColor : LightBackgroundColor;
    public static Color windowAccent => EditorGUIUtility.isProSkin ? DarkBorder : LightBorder;
    public static readonly Color32 lowerPriorityColor = new Color32(255, 140, 144, 255);
    public static readonly Color32 selfColor = new Color32(71, 255, 166, 255);
    private static readonly Color32 DarkBackgroundColor = new Color32(56, 56, 56, 255);
    private static readonly Color32 LightBackgroundColor = new Color32(200, 200, 200, 255);
    private static readonly Color32 DarkBorder = new Color32(40, 40, 40, 255);
    private static readonly Color32 LightBorder = new Color32(147, 147, 147, 255);
    //Textures
    private static Texture2D _node;
    private static Texture2D _nodeSelected;
    private static Texture2D _arrow;
    private static Texture2D _nodeSelectedDecorator;
    private static Texture2D _solid;
    private static Texture2D _blackboardIcon;
    private static Texture2D _dropdown;
    private static Texture2D _warnIcon;
    private static Texture2D _errorIcon;
    private static Texture2D _infoIcon;
    private static Texture2D _searchIcon;
    private static Texture2D _splashImage;
    private static Texture2D _plus;
    private static Texture2D _minus;
    private static Texture2D _gridTexture;
    private static Texture2D _circle;
    private static Texture2D _global;
    private static Texture2D _local;
    private static Texture2D _shared;
    private static Texture2D _preAudioLoopOff;
    private static GUIContent _visibilityToggleOffContent;
    private static GUIContent _visibilityToggleOnContent;
    public static Texture2D warnIcon => _warnIcon != null ? _warnIcon : _warnIcon = EditorGUIUtility.FindTexture("console.warnicon");
    public static Texture2D errorIcon => _errorIcon != null ? _errorIcon : _errorIcon = EditorGUIUtility.FindTexture("console.erroricon");
    public static Texture2D infoIcon => _infoIcon != null ? _infoIcon : _infoIcon = EditorGUIUtility.FindTexture("console.infoicon");
    public static Texture2D searchIcon => _searchIcon != null ? _searchIcon : _searchIcon = EditorGUIUtility.FindTexture("Search Icon");
    public static Texture2D splashImage => _splashImage != null ? _splashImage : _splashImage = Resources.Load<Texture2D>("splash");
    public static Texture2D node => _node != null ? _node : _node = Resources.Load<Texture2D>("node");
    public static Texture2D nodeSelected => _nodeSelected != null ? _nodeSelected : _nodeSelected = Resources.Load<Texture2D>("node_highlight");
    public static Texture2D arrow => _arrow != null ? _arrow : _arrow = Resources.Load<Texture2D>("arrow");
    public static Texture2D blackboardIcon => _blackboardIcon != null ? _blackboardIcon : _blackboardIcon = Resources.Load<Texture2D>("blackboard_key");
    public static Texture2D plus => _plus != null ? _plus : _plus = EditorGUIUtility.FindTexture("Toolbar Plus More");
    public static Texture2D minus => _minus != null ? _minus : _minus = EditorGUIUtility.FindTexture("Toolbar Minus");
    public static Texture2D circle => _circle != null ? _circle : _circle = Resources.Load<Texture2D>("Circle");
    public static Texture2D solid => _solid != null ? _solid : _solid = GenerateSolid(Color.white, new Vector2Int(32, 32));
    public static Texture2D local => _local != null ? _local : _local = (Texture2D)EditorGUIUtility.IconContent("ModelImporter Icon").image;
    public static Texture2D global => _global != null ? _global : _global = EditorGUIUtility.FindTexture("Profiler.GlobalIllumination");
    public static Texture2D shared => _shared != null ? _shared : _shared = EditorGUIUtility.FindTexture("Linked");
    public static Texture2D preAudioLoopOff => _preAudioLoopOff != null ? _preAudioLoopOff : _preAudioLoopOff = EditorGUIUtility.FindTexture("preAudioLoopOff@2x");
    public static GUIContent visibilityToggleOffContent => _visibilityToggleOffContent != null ? _visibilityToggleOffContent : _visibilityToggleOffContent = new GUIContent(EditorGUIUtility.FindTexture("animationvisibilitytoggleoff"), "Toggle Inspector On");
    public static GUIContent visibilityToggleOnContent => _visibilityToggleOnContent != null ? _visibilityToggleOnContent : _visibilityToggleOnContent = new GUIContent("", EditorGUIUtility.FindTexture("animationvisibilitytoggleon"), "Toggle Inspector Off");
    public static Texture2D gridTexture => _gridTexture == null ? _gridTexture = GenerateGridTexture(Color.grey, windowBackground) : _gridTexture;
    private static Texture2D _crossTexture;
    public static Texture2D crossTexture => _crossTexture == null ? _crossTexture = GenerateCrossTexture(Color.gray) : _crossTexture;
    private static Texture2D _searchBackground;
    public static Texture2D searchBackground
    {
        get { return _searchBackground == null ? _searchBackground = GenerateSolid(Styles.windowBackground, new Vector2Int(1, 1)) : _searchBackground; }
    }
    private static Texture2D _favorite;
    public static Texture2D favorite => _favorite == null ? _favorite = FindTexture("Favorite On Icon") : _favorite;
    private static Texture2D _folder;
    public static Texture2D folder => _folder == null ? _folder = (Texture2D)EditorGUIUtility.IconContent("Folder Icon").image : _folder;
    private static Texture2D _folderOpen;
    public static Texture2D folderOpen => _folderOpen == null ? _folderOpen = FindTexture("FolderOpened Icon") : _folderOpen;
    private static Texture2D _next;
    public static Texture2D next => _next == null ? _next = FindTexture("tab_next") : _next;
    private static Texture2D _prev;
    public static Texture2D prev => _prev == null ? _prev = FindTexture("tab_prev") : _prev;
    private static Texture2D _menu;
    public static Texture2D menu => _menu == null ? _menu = FindTexture("_Menu") : _menu;
    private static Texture2D _inspectorIcon;
    public static Texture2D inspectorIcon => _inspectorIcon == null ? _inspectorIcon = FindTexture("UnityEditor.InspectorWindow") : _inspectorIcon;
    private static Texture2D _hiearchyIcon;
    public static Texture2D hiearchyIcon => _hiearchyIcon == null ? _hiearchyIcon = FindTexture("UnityEditor.HierarchyWindow") : _hiearchyIcon;
    private static GUIStyle _quickSearch;
    public static GUIStyle quickSearch
    {
        get
        {
            if (_quickSearch == null)
            {
                _quickSearch = new GUIStyle();
                _quickSearch.normal.background = searchBackground;
                _quickSearch.padding = new RectOffset(0, 0, 8, 8);
            }

            return _quickSearch;
        }
    }
    private static GUIStyle _blackboardScroll;
    public static GUIStyle blackboardScroll
    {
        get
        {
            if (_blackboardScroll == null)
            {
                _blackboardScroll = new GUIStyle(EditorStyles.helpBox);
                _blackboardScroll.padding = new RectOffset(0, 0, 0, 0);
            }

            return _blackboardScroll;
        }
    }
    private static GUIStyle _padding8x;
    public static GUIStyle padding8x
    {
        get
        {
            if (_padding8x == null)
            {
                _padding8x = new GUIStyle();
                _padding8x.padding = new RectOffset(8, 8, 8, 8);
            }

            return _padding8x;
        }
    }
    private static GUIStyle _searchHighlight;
    public static GUIStyle searchHighlight
    {
        get
        {
            if (_searchHighlight == null)
            {
                _searchHighlight = new GUIStyle(EditorStyles.boldLabel);
                _searchHighlight.padding = new RectOffset(0, 0, 0, 0);
                _searchHighlight.margin = new RectOffset(0, 0, 0, 0);
                _searchHighlight.contentOffset = new Vector2(0, 0);
                _searchHighlight.normal.textColor = Color.yellow;
                _searchHighlight.hover.textColor = Color.yellow;
            }

            return _searchHighlight;
        }
    }
    private static GUIStyle _searchResult;
    public static GUIStyle searchResult
    {
        get
        {
            if (_searchResult == null)
            {
                _searchResult = new GUIStyle(EditorStyles.label);
                _searchResult.padding = new RectOffset(0, 0, 0, 0);
                _searchResult.margin = new RectOffset(0, 0, 0, 0);
            }

            return _searchResult;
        }
    }
    private static GUIStyle _searchTitle;
    public static GUIStyle searchTitle
    {
        get
        {
            if (_searchTitle == null)
            {
                _searchTitle = new GUIStyle(EditorStyles.boldLabel);
                _searchTitle.fontSize = 16;
            }

            return _searchTitle;
        }
    }
    private static StylesObj _styles;
    public static StylesObj styles => _styles ??= new StylesObj();
    private static Texture2D FindTexture(string baseName)
    {
        bool darkMode = EditorGUIUtility.isProSkin;
        string name = (darkMode ? "d_" : "") + baseName;

        Texture2D tex = (Texture2D)EditorGUIUtility.IconContent(baseName).image;

        if (tex != null)
            return tex;

        tex = EditorGUIUtility.FindTexture(baseName);

        return tex;
    }
    private static Texture2D GenerateGridTexture(Color line, Color bg)
    {
        Texture2D tex = new Texture2D(64, 64);
        Color[] cols = new Color[64 * 64];
        for (int y = 0; y < 64; y++)
        {
            for (int x = 0; x < 64; x++)
            {
                Color col = bg;
                if (y % 16 == 0 || x % 16 == 0) col = Color.Lerp(line, bg, 0.65f);
                if (y == 63 || x == 63) col = Color.Lerp(line, bg, 0.35f);
                cols[(y * 64) + x] = col;
            }
        }
        tex.SetPixels(cols);
        tex.wrapMode = TextureWrapMode.Repeat;
        tex.filterMode = FilterMode.Bilinear;
        tex.name = "Grid";
        tex.Apply();
        return tex;
    }
    public static Texture2D GenerateSolid(Color color, Vector2Int size)
    {
        Texture2D tex = new Texture2D(size.y, size.x);
        for (int y = 0; y < size.y; y++)
        {
            for (int x = 0; x < size.x; x++)
            {
                tex.SetPixel(x, y, color);
            }
        }
        tex.wrapMode = TextureWrapMode.Repeat;
        tex.name = "Solid"; tex.Apply(); return tex;
    }
    private static Texture2D GenerateCrossTexture(Color line)
    {
        Texture2D tex = new Texture2D(64, 64);
        Color[] cols = new Color[64 * 64];
        for (int y = 0; y < 64; y++)
        {
            for (int x = 0; x < 64; x++)
            {
                Color col = line;
                if (y != 31 && x != 31) col.a = 0;
                cols[(y * 64) + x] = col;
            }
        }
        tex.SetPixels(cols);
        tex.wrapMode = TextureWrapMode.Clamp;
        tex.filterMode = FilterMode.Bilinear;
        tex.name = "Grid";
        tex.Apply();
        return tex;
    }
    public class StylesObj
    {
        public readonly GUIStyle node, nodeWithoutPadding, decorator, title, nodeLabel, nodeText, nodeSelected, newNode, addNodeWindow, backgroundBg, searchbar, searchResult, minimap, nameField;
        ///<summary>
        ///Generates Styles object which is used in the Node Editor GUI
        ///</summary>
        public StylesObj()
        {
            //node style
            node = new GUIStyle
            {
                normal =
                {
                    background = global::Styles.node
                },
                border = new RectOffset(8, 8, 8, 8),
                padding = new RectOffset(16, 16, 16, 16)
            };

            //node style (no padding)
            nodeWithoutPadding = new GUIStyle
            {
                normal =
                {
                    background = global::Styles.node
                },
                border = new RectOffset(8, 8, 8, 8),
            };

            //selected node style
            nodeSelected = new GUIStyle
            {
                normal =
                {
                    background = global::Styles.nodeSelected
                },
                border = new RectOffset(8, 8, 8, 8)
            };

            decorator = new GUIStyle
            {
                normal =
                {
                    background = global::Styles.node
                },
                border = new RectOffset(8, 8, 8, 8),
                contentOffset = Vector2.zero,
                margin = new RectOffset(0, 0, 0, 0),
                padding = new RectOffset(0, 0, 0, 0)
            };

            title = new GUIStyle("LargeLabel")
            {
                alignment = TextAnchor.MiddleCenter
            };

            nodeLabel = new GUIStyle("Label")
            {
                alignment = TextAnchor.MiddleCenter,
                fontSize = 15
            };

            nodeText = new GUIStyle
            {
                alignment = TextAnchor.MiddleCenter,
                fontSize = 12,
                normal =
                {
                    textColor = Color.white
                }
            };

            //new node result item style
            newNode = new GUIStyle
            {
                normal =
                {
                    background = global::Styles.node,
                    textColor = Color.black
                },
                border = new RectOffset(32, 32, 32, 32),
                padding = new RectOffset(0, 0, 4, 16),
                alignment = TextAnchor.MiddleCenter
            };

            addNodeWindow = new GUIStyle(GUI.skin.window)
            {
                normal =
                {
                    background = GenerateSolid(windowAccent, Vector2Int.one * 32)
                },
                onNormal =
                {
                    background = GenerateSolid(windowAccent, Vector2Int.one * 32)
                },
                margin = new RectOffset(0, 0, 0, 0),
                padding = new RectOffset(0, 0, 16, 0)
            };

            backgroundBg = new GUIStyle
            {
                normal =
                {
                    background = GenerateSolid(windowBackground, Vector2Int.one * 32)
                }
            };

            searchbar = new GUIStyle
            {
                alignment = TextAnchor.MiddleLeft,
                normal =
                {
                    textColor = Color.white
                }
            };

            searchResult = new GUIStyle
            {
                alignment = TextAnchor.MiddleLeft,
                normal =
                {
                    textColor = Color.white,
                    background = GenerateSolid(Color.white, Vector2Int.one * 32)
                },
                margin = new RectOffset(0, 0, 0, 0),
                padding = new RectOffset(8, 8, 8, 8),
                hover =
                {
                    textColor = Color.gray
                },
            };

            nameField = new GUIStyle("PR TextField");
        }
    }
}
