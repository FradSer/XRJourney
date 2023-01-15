using UnityEngine;

public class MoveGaze : MonoBehaviour
{
  private static readonly int SightInto = Animator.StringToHash("Sight Into");
  private static readonly int SightOut = Animator.StringToHash("Sight Out");

  public GameObject dock;
  public GameObject dockDisabler;

  private Animator _animator;
  private float _gazeTimer;
  private bool _hasTriggered;
  private bool _isGazing;
  private GameObject _lookedAtObject;

  private void Start()
  {
    _animator = dock.GetComponent<Animator>();
    _gazeTimer = 0f;
    _isGazing = false;
    _hasTriggered = false;
  }

  private void Update()
  {
    var rayTransform = transform;
    var ray = new Ray(rayTransform.position, rayTransform.forward);

    if (!Physics.Raycast(ray, out var hit, 100f)) return;
    _lookedAtObject = hit.collider.gameObject;
    if (_lookedAtObject == dock)
    {
      _gazeTimer += Time.deltaTime;
      _isGazing = true;
      if (!(_gazeTimer > 0.1f) || _hasTriggered) return;
      _animator.SetTrigger(SightInto);
      _hasTriggered = true;
    }
    else if (_isGazing & (_lookedAtObject == dockDisabler))
    {
      _animator.SetTrigger(SightOut);
      _gazeTimer = 0f;
      _isGazing = false;
      _hasTriggered = false;
    }
  }
}