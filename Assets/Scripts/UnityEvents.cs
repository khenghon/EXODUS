using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


[System.Serializable]
public class ObjectGrabbedEvent : UnityEvent<GameObject> { }

[System.Serializable]
public class ObjectDroppedEvent : UnityEvent<GameObject> { }