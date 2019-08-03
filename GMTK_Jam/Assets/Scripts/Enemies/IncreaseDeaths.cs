using UnityEngine;

public class IncreaseDeaths : MonoBehaviour
{
    public bool IsBasic;

    public bool IsMedium;

    private void OnDestroy()
    {
        if(IsBasic)
            GameManager.GetInstance().IncreaseBasicEnemeiesDefeated();
        if (IsMedium)
            GameManager.GetInstance().IncreaseMediumEnemeiesDefeated();
        
        Debug.Log("basic : " + GameManager.GetInstance().GetBasicEnemeiesDefeated());
        Debug.Log("medium : " + GameManager.GetInstance().GetMediumEnemeiesDefeated());
    }
}
