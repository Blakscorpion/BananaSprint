using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_LevelManager : MonoBehaviour
{
    public int StartFloorAmount = 3;
    public float offsetBetweenFloor = 3f;
    public float AnimationTime = 2f;

    [Header("GameObject")]
    public GameObject Floor;
    public Camera MainCam;

    float _currentOffset = 0;
    float _currentFloorScaleX = 0.9f;
    Vector3 OriginPosition;
    List<GameObject> _floorSpawned = new List<GameObject>();

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
            AddFloor(1);
    }

    private void Start()
    {
        //Init floor 
        AddFloor(StartFloorAmount, false);
    }

    void AddFloor(int _amount = 1, bool _animation = true)
    {
        //Instantiate Floor Prefab
        for (int i = 0; i < _amount; i++)
        {
            InstantiateFloor();
        }
        _currentFloorScaleX += 0.5f;

        AnimateGameMesh();

        if (_animation)
        {
            //New position to lerp 
            float newCamOrthoSize = MainCam.orthographicSize + 1.5f * _amount;
            float newCamTransformPosY = MainCam.transform.position.y + 1.5f * _amount;

            MainCamAnimation(newCamOrthoSize, newCamTransformPosY);

        }
    }
    void MainCamAnimation(float _newCamOrthoSize, float _newCamTransformPosY)
    {
        //Dotween Sequence
        Sequence mySequence = DOTween.Sequence();

        mySequence.Join(MainCam.DOOrthoSize(_newCamOrthoSize, AnimationTime));
        mySequence.Join(MainCam.transform.DOMoveY(_newCamTransformPosY, AnimationTime));

        mySequence.Play();
    }

    float beginDoorPos = 3.75f;
    float doorPosOffset = 3.25f;
    void AnimateGameMesh()
    {
        beginDoorPos += doorPosOffset;
        foreach (GameObject _floor in _floorSpawned)
        {
            _floor.transform.GetChild(0).DOScaleX(_currentFloorScaleX, AnimationTime);

            _floor.transform.GetChild(1).DOMoveX(beginDoorPos, AnimationTime);
            _floor.transform.GetChild(2).DOMoveX(-beginDoorPos, AnimationTime);
        }
    }

    void InstantiateFloor()
    {
        //Instantiate Floor
        Vector3 vectorOffset = new Vector3(0, _currentOffset, 0);
        GameObject _tmpFloor;
        _tmpFloor = Instantiate(Floor, vectorOffset, Quaternion.identity);

        //Change Scale to fit new Camera Ortho size
        Vector3 _tmpFloorScale = _tmpFloor.transform.GetChild(0).localScale;
        _tmpFloor.transform.GetChild(0).localScale = new Vector3(_currentFloorScaleX, _tmpFloorScale.y, _tmpFloorScale.z);

        _floorSpawned.Add(_tmpFloor);

        _currentOffset += offsetBetweenFloor;
    }
}
