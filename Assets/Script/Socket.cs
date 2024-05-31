using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Socket : XRSocketInteractor
{
    public string targetTag;

    public override bool CanHover(IXRHoverInteractable interact)
    {
        return base.CanHover(interact) && interact.transform.tag == targetTag;
    }

    public override bool CanSelect(IXRSelectInteractable interact)
    {
        return base.CanSelect(interact) && interact.transform.transform.tag == targetTag;
    }
}
