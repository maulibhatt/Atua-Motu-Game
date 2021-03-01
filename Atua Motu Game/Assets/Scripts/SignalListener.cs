using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SignalListener : MonoBehaviour
{

    public SignalSender signal;
    public UnityEvent signalEvent;

    public void OnSignalRaised()
    {
        // Calls the event
        signalEvent.Invoke();
    }

    // Registers the event in the SignalSender
    private void OnEnable(){
        signal.RegisterListener(this);
    }

    private void OnDisable(){
        signal.UnregisterListener(this);
    }
}
