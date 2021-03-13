using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scripts/Signal Sender", fileName = "New Signal")]
public class SignalSender : ScriptableObject
{
    // List of signal listeners of everything that is listening to this
    public List<SignalListener> listeners = new List<SignalListener>();

    // Loops through all signal listeners and raises a method
    public void Raise()
    {
        for (int i = listeners.Count -1; i >= 0; i--)
        {
            listeners[i].OnSignalRaised();
        }
    }

    // Add listener to list
    public void RegisterListener(SignalListener listener)
    {
        listeners.Add(listener);
    }

    // Remove listener from list
    public void UnregisterListener(SignalListener listener)
    {
        listeners.Remove(listener);
    }

}
