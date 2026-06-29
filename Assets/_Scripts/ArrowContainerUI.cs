using UnityEngine;

public class ArrowContainerUI : MonoBehaviour
{
    [SerializeField] GameObject _arrowTemplate;

    private void Start()
    {
        ArrowGenerator.OnArrowListGenerated += ArrowGenerator_OnArrowListGenerated;
        ArrowGenerator.OnCorrectArrowPressed += ArrowGenerator_OnCorrectArrowPressed;
        ArrowGenerator.OnWrongArrowPressed += ArrowGenerator_OnWrongArrowPressed;
        Player.OnPlayerSwitch += Player_OnPlayerSwitch;
    }

    private void ArrowGenerator_OnWrongArrowPressed(object sender, System.EventArgs e)
    {
        foreach (Transform child in transform)
        {
            if (child.gameObject == _arrowTemplate)
            {
                continue;
            }
            child.GetComponent<ArrowTemplateUI>().SetArrowStatus(Color.red);
        }
    }

    private void ArrowGenerator_OnCorrectArrowPressed(object sender, ArrowGenerator.OnCorrectArrowPressedEventArgs e)
    {
        Transform arrowTransform = transform.GetChild(e.arrowIndex + 1);
        arrowTransform.GetComponent<ArrowTemplateUI>().SetArrowStatus(Color.green);
        arrowTransform.GetComponent<Animator>().SetTrigger("Key");

    }

    private void Player_OnPlayerSwitch(object sender, System.EventArgs e)
    {
        bool visible = false;
        if (Player.PlayerInOfficeMode())
        {
            visible = false;
        }
        else
            visible = true;
        foreach (Transform child in transform)
        {
            if (child.gameObject == _arrowTemplate)
            {
                continue;
            }
            child.gameObject.SetActive(visible);
        }
    }

    private void ArrowGenerator_OnArrowListGenerated(object sender, ArrowGenerator.OnArrowGeneratedEventArgs e)
    {
        
        if (transform.childCount > 1)
        {
            foreach (Transform child in transform)
            {
                if (child.gameObject == _arrowTemplate)
                {
                    continue;
                }
                Destroy(child.gameObject);
            }
        }
        foreach (ArrowGenerator.arrow arrow in e.generatedArrowList)
        {
            GameObject arrowUI = Instantiate(_arrowTemplate, transform);
            if(Player.PlayerInOfficeMode() == false)
            arrowUI.SetActive(true);

            arrowUI.GetComponent<ArrowTemplateUI>().SetArrow(arrow);
        }
    }

    private void OnDestroy()
    {
        ArrowGenerator.OnArrowListGenerated -= ArrowGenerator_OnArrowListGenerated;
        ArrowGenerator.OnCorrectArrowPressed -= ArrowGenerator_OnCorrectArrowPressed;
        ArrowGenerator.OnWrongArrowPressed -= ArrowGenerator_OnWrongArrowPressed;
        Player.OnPlayerSwitch -= Player_OnPlayerSwitch;
    }

}
