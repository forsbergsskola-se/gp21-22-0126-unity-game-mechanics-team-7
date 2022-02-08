using System.Collections;
using UnityEngine;

public class Geyser : MonoBehaviour {
    [SerializeField] private float rayCastSphereRadius = 3f;
    [SerializeField] private float range = 10f;
    [SerializeField] private float geyserForce = 220f;
    [SerializeField] private float eruptionDuration = 2.5f;
    [SerializeField] private float reposeInterval = 2f;
    [SerializeField] private ParticleSystem bubbles;

    private RaycastHit _hit;
    
    private bool _canErupt = true;
    private bool _objectFoundInArea;

    private void Start() {
        StartCoroutine(Eruption());
    }

    private void FixedUpdate() {
        //Checks for objects
        _objectFoundInArea = Physics.SphereCast(transform.position, rayCastSphereRadius, transform.up, out _hit, range);
        
        if (_objectFoundInArea && _canErupt) {
            //Adds force to rigidbodies in the sphere cast
            if (_hit.rigidbody != null) {
                _hit.rigidbody.AddForce(transform.up * geyserForce, ForceMode.Force);
            }
        }
    }

    //Method that handles the eruption cycle, eruption cycle is always active
    private IEnumerator Eruption() {
        while (true) {
            bubbles.Play();
            _canErupt = true;
            
            yield return new WaitForSeconds(eruptionDuration);
            
            bubbles.Stop();
            _canErupt = false;
            
            yield return new WaitForSeconds(reposeInterval);
        }
    }
    
    private void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, transform.up * range);
        Gizmos.DrawWireSphere(transform.position + transform.up * _hit.distance, rayCastSphereRadius);
    }
}
