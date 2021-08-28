using System.Collections;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using TMPro;


public class GameplayHand : BaseHand
{
    // The interactor we react to
    [SerializeField] private XRBaseInteractor targetInteractor = null;


    public MenuManager menuManager;

    //testing text
    // public TMP_Text test;

    // apply default pose
    private void TryApplyDefaultPose()
    {
        ApplyDefaultPose();
    }

    public override void ApplyOffset(Vector3 position, Quaternion rotation)
    {
        Vector3 finalPosition = position * -1.0f;
        Quaternion finalRotation = Quaternion.Inverse(rotation);

        finalPosition = finalPosition.RotatePointAroundPivot(Vector3.zero, finalRotation.eulerAngles);

        targetInteractor.attachTransform.localPosition = finalPosition;
        targetInteractor.attachTransform.localRotation = finalRotation;
    }


    private void OnValidate()
    {
        if (!targetInteractor)
        {
           targetInteractor = GetComponent<XRBaseInteractor>();
        }
    }


    //Hand trigger detection
    public void OnTriggerEnter(Collider target)
    {
        //test.text = target.tag.ToString();
        if (target.tag == "ActivationArea")
        {
            ApplyActivationPose();
        }

        if (target.tag == "SettingActivator")
        {
            menuManager.ChangeSettingMenu();
        }

        if (target.tag == "PlayActivator")
        {
            menuManager.StartGame();
        }

    }

    public void OnTriggerExit(Collider target)
    {
        if (target.tag == "ActivationArea")
        {
            TryApplyDefaultPose();
        }
    }
}