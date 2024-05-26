using System;
using UnityEngine;
using UnityEngine.UI;


public enum MapNodeUIStates
{
    Locked,
    Visited,
    Attainable
}

public class MapNodeUI : MonoBehaviour
{
    const int k_startLevelIndex = SceneConstants.Level_1;
    [Header("Level Loader")]
    [SerializeField] int levelIndex;
    Button button;

    public SpriteRenderer sr;
    public Image image;
    public MapNode mapNode { get; private set; }
    public MapNodeTypeSO mapNodeType { get; private set; }

    private MapNodeUIStates mapNodeUIState;

    public void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(() => TryEnterNode());
    }

    public void SetUp(MapNode node, MapNodeTypeSO mapNodeType, int index)
    {
        mapNode = node;
        this.mapNodeType = mapNodeType;
        if (sr != null) sr.sprite = mapNodeType.Icon;
        if (image != null) image.sprite = mapNodeType.Icon;
        if (node.type == MapNodeType.Boss) transform.localScale *= 1.5f;
        levelIndex = index;
        SetState(MapNodeUIStates.Locked);
        
    }

    public void SetState(MapNodeUIStates state)
    {
        mapNodeUIState = state;
        switch (state)
        {
            case MapNodeUIStates.Locked:
                if (sr != null)
                {
                    sr.color = MapDrawerUI.Instance.lockedColor;
                }

                if (image != null)
                {
                    image.color = MapDrawerUI.Instance.lockedColor;
                }

                break;
            case MapNodeUIStates.Visited:
                if (sr != null)
                {
                    sr.color = MapDrawerUI.Instance.visitedColor;
                }

                if (image != null)
                {
                    image.color = MapDrawerUI.Instance.visitedColor;
                }
                break;
            case MapNodeUIStates.Attainable:
                // start pulsating from visited to locked color:
                if (sr != null)
                {
                    sr.color = MapDrawerUI.Instance.attainableColor;
                }

                if (image != null)
                {
                    image.color = MapDrawerUI.Instance.attainableColor;
                }

                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(state), state, null);
        }
    }

    private void TryEnterNode()
    {
        if(mapNodeUIState == MapNodeUIStates.Attainable) 
        {         
            MapPlayerTracker.Instance.SendPlayerToNode(this);
        }
        else
        {
            Debug.Log("Selected node cannot be accessed");
        }

    }

    public void LoadNodeLevel()
    {
        //TODO LOAD SCENE THAT WE WANT
        //int currentIndex = levelIndex + k_startLevelIndex;
        //SceneLoader.Instance.LoadScene(currentIndex);

        Debug.Log("Entering node of type: " + mapNode.type);

        switch (mapNode.type)
        {
            case MapNodeType.Arena:
                break;
            case MapNodeType.Armory:
                break;
            case MapNodeType.Boss:
                break;
            case MapNodeType.Experience:
                break;
            case MapNodeType.Forge:
                break;
            case MapNodeType.Temple:
                break;
            case MapNodeType.WeaponReroll:
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }

    }

}

