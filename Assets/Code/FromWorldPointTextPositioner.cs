using UnityEngine;

public class FromWorldPointTextPositioner //: IFloatingTextPositioner
{
    private readonly Camera _camera;
    private readonly Vector3 _worldPosition;
    private float _timeToLive;
    private readonly float _speed;

    public FromWorldPointTextPositioner(Camera camera, Vector3 worldPosition, float timeToLive, float speed)
    {
        _camera = camera;
        _worldPosition = worldPosition;
        _timeToLive = timeToLive;
        _speed = speed;
    }
    
    //    public bool GetPosition(ref Vector2 position, GUIContent content, Vector2 size)
    //{
        
    //}
}

