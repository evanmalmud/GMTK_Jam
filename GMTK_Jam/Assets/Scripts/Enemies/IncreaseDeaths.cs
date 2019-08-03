using UnityEngine;

public class IncreaseDeaths : MonoBehaviour
{
    public bool IsBasic;

    public bool IsMedium;

    public int points;

    private void OnDestroy()
    {
        if(IsBasic)
            GameManager.GetInstance().IncreaseBasicEnemeiesDefeated();
        if (IsMedium)
            GameManager.GetInstance().IncreaseMediumEnemeiesDefeated();

        GameManager.GetInstance().IncreaseScore(new Vector2(gameObject.transform.position.x, gameObject.transform.position.y), points);
        //Debug.Log("basic : " + GameManager.GetInstance().GetBasicEnemeiesDefeated());
        //Debug.Log("medium : " + GameManager.GetInstance().GetMediumEnemeiesDefeated());
    }
}
