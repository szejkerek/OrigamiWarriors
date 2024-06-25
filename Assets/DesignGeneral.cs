using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualHelper
{
    public static int GetNextIndex(int currentIndex, int count)
    {
        return (currentIndex + 1) % count;
    }

    public static int GetPrevIndex(int currentIndex, int count)
    {
        return (currentIndex - 1) % count;
    }
}


public class DesignGeneral : MonoBehaviour
{
    public SamuraiNames names;
    public SamuraiVisualsSO maleVisuals;
    public Character general;
    [SerializeField] CharacterUIDisplay display;
    private void Start()
    {
        general = SavableDataManager.Instance.data.team.General;
        display.Init(general);
    }

    public void LoadChooseMap()
    {
        SceneLoader.Instance.LoadScene(SceneConstants.ChooseLevelScene);
    }

    public void RanomizeName()
    {
        general.Name = names.GetRandomName();
        display.Init(general);
    }

    public void NextHelmetF()
    {
        general.SamuraiVisuals.helmetFIndex = VisualHelper.GetNextIndex(general.SamuraiVisuals.helmetFIndex, maleVisuals.Helmet_F.Count);
        display.Init(general);
    }

    public void NextHelmetB()
    {
        general.SamuraiVisuals.helmetBIndex = VisualHelper.GetNextIndex(general.SamuraiVisuals.helmetBIndex, maleVisuals.Helmet_B.Count);
        display.Init(general);
    }

    public void NextFace()
    {
        general.SamuraiVisuals.faceIndex = VisualHelper.GetNextIndex(general.SamuraiVisuals.faceIndex, maleVisuals.Face_F.Count);
        display.Init(general);
    }

    public void NextHead()
    {
        general.SamuraiVisuals.headIndex = VisualHelper.GetNextIndex(general.SamuraiVisuals.headIndex, maleVisuals.Head.Count);
        display.Init(general);
    }

    public void NextPants()
    {
        general.SamuraiVisuals.pantsIndex = VisualHelper.GetNextIndex(general.SamuraiVisuals.pantsIndex, maleVisuals.Pants.Count);
        display.Init(general);
    }

    // Previous item methods
    public void PrevHelmetF()
    {
        general.SamuraiVisuals.helmetFIndex = VisualHelper.GetPrevIndex(general.SamuraiVisuals.helmetFIndex, maleVisuals.Helmet_F.Count);
        display.Init(general);
    }

    public void PrevHelmetB()
    {
        general.SamuraiVisuals.helmetBIndex = VisualHelper.GetPrevIndex(general.SamuraiVisuals.helmetBIndex, maleVisuals.Helmet_B.Count);
        display.Init(general);
    }

    public void PrevFace()
    {
        general.SamuraiVisuals.faceIndex = VisualHelper.GetPrevIndex(general.SamuraiVisuals.faceIndex, maleVisuals.Face_F.Count);
        display.Init(general);
    }

    public void PrevHead()
    {
        general.SamuraiVisuals.headIndex = VisualHelper.GetPrevIndex(general.SamuraiVisuals.headIndex, maleVisuals.Head.Count);
        display.Init(general);
    }

    public void PrevPants()
    {
        general.SamuraiVisuals.pantsIndex = VisualHelper.GetPrevIndex(general.SamuraiVisuals.pantsIndex, maleVisuals.Pants.Count);
        display.Init(general);
    }
}
