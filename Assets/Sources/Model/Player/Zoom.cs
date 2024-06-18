using UnityEngine;
using System;

namespace Game.Model
{
    public class Zoom
    {
        private readonly Camera _camera;
        private readonly float _timeZoom;
        private readonly float _zoom;
        private readonly float _speedZoom;
        private readonly float _startZoom;

        public Zoom(Camera Camera, float Zoom, float ZimeZoomSecond,float SpeedZoom)
        {
            _camera = Camera;
            _timeZoom = ZimeZoomSecond;
            _zoom = Zoom;
            _speedZoom = SpeedZoom;
            _startZoom = _camera.fieldOfView;
        }

        public void Zooming(float delta,bool isActivateScaling)
        {
            if(delta < 0)
                throw new InvalidOperationException(nameof(delta));

            if (isActivateScaling)
                Zooms(delta,_zoom);
            else
                Zooms(delta,_startZoom);
        }

        private void Zooms(float delta, float zoom) => _camera.fieldOfView = Mathf.Lerp(_camera.fieldOfView, zoom, delta * _speedZoom / _timeZoom);
    }
}
