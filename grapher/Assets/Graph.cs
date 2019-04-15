using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graph : MonoBehaviour
{

    [Range(10, 100)] public int resolution = 10;

    public Transform pointPrefab;
    Transform[] points;


    // Start is called before the first frame update
    void Start() {
        Vector3 position;
        position.y = 0f;
        position.z = 0f;
        
        float step = 2f / resolution;
        Vector3 scale = Vector3.one * step;

        points = new Transform[resolution];
        
        for (int i=0; i<resolution; i++) {
            Transform point = Instantiate(pointPrefab);
            position.x = ((i + 0.5f) * step) - 1f;

            point.localPosition = position;
            point.localScale = scale;
            point.SetParent(transform, false);
            
            points[i] = point;
        }

    }

    float function(float x) {
        return Mathf.Sin(Mathf.PI * (x + Time.time));
    }

    // Update is called once per frame
    void Update() {
        for (int i=0; i < points.Length; i++) {
            Transform point = points[i];
            Vector3 position = point.localPosition;
            position.y = function(position.x);
            point.position = position;
        }
    }
}
