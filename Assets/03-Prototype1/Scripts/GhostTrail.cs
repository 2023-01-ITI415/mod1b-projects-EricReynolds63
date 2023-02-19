using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class GhostTrail : MonoBehaviour
{
    static List<GhostTrail> GHOST_LINES = new List<GhostTrail>();
    private const float DIM_MULT = 0.75f;

    private LineRenderer    _line;
    private bool            _drawing = true;
    private Ghost		    _ghost;

    static void ADD_LINE( GhostTrail newLine)
    {
        Color col;
        foreach (GhostTrail pl in GHOST_LINES) {
            col = pl._line.startColor;
            col = col * DIM_MULT;
            pl._line.startColor = pl._line.endColor = col;
        }
        GHOST_LINES.Add(newLine);
    }

    // Start is called before the first frame update
    void Start()
    {
        _line = GetComponent<LineRenderer>();
        _line.positionCount = 1;
        _ghost = GetComponentInParent<Ghost>();
		_line.SetPosition(0, _ghost.transform.position);

        ADD_LINE(this);
    }

    void FixedUpdate()
    {
        if (_drawing)
        {
            _line.positionCount++;
            _line.SetPosition(_line.positionCount - 1, transform.position);
            if (_ghost != null) {
                _drawing = false;
                _ghost = null;
            }
        }
    }

    private void OnDestroy()
    {
        GHOST_LINES.Remove(this);
    }
}
