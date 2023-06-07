using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    [SerializeField] private List<TutorialStep> steps;

    private int currentTutorialIndex = 0;

    [SerializeField] private TextMeshProUGUI titleText;
    [SerializeField] private TextMeshProUGUI descriptionText;
    [SerializeField] private TextMeshProUGUI nextButtonText;
    [SerializeField] private Button nextButton;
    [SerializeField] private Button prevButton;
    [SerializeField] private GameObject canvasObject;

    private void Awake()
    {
        steps = new List<TutorialStep>();

        steps.Add(new TutorialStep("Rotate Camera", "Use the A&D keys on the keyboard"));
        steps.Add(new TutorialStep("Zoom camera", "Use the scroll wheel to zoom in and out"));
        steps.Add(new TutorialStep("Move an Unit", "Click on a tile next to the unit to move it there"));
        steps.Add(new TutorialStep("Attack an unit", "Click on another unit to attack with the current selected unit"));

        nextButton.onClick.AddListener(ShowNextTutorial);
        prevButton.onClick.AddListener(ShowPrevTutorial);

        UpdateShownTutorial();
    }

    private void ShowNextTutorial()
    {
        currentTutorialIndex++;

        if(currentTutorialIndex > steps.Count - 1)
        {
            CloseWindow();
            return;
        }

        if(currentTutorialIndex == steps.Count - 1)
        {
            nextButtonText.text = "Close";
        }
        else
        {
            nextButtonText.text = "Next";
        }

        UpdateShownTutorial();
    }

    private void ShowPrevTutorial()
    {
        currentTutorialIndex--;
        UpdateShownTutorial();
    }

    private void UpdateShownTutorial()
    {
        titleText.text = steps[currentTutorialIndex].title;
        descriptionText.text = steps[currentTutorialIndex].description;
    }

    private void CloseWindow()
    {
        canvasObject.SetActive(false);
    }
}
