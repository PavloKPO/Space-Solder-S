using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private Transform _target;
    [SerializeField] private float _speedEnemy;
    [SerializeField] private float _speedPatrol;
    [SerializeField] private float _obstacleRange;
    [SerializeField] private float _health;
    private Rigidbody _rbEnemy;
    private bool _isPlayer = false;
    private bool _isDeath;
    private void Start()
    {
        _rbEnemy = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        if (_isDeath == false)
        {
            EnemyAnimator();
            EnemyBehaviour();
        }
    }

    private void EnemyAnimator()
    {
        if (_rbEnemy.velocity.magnitude != 0)
            _animator.SetBool("EnemyMove", true);
        else
            _animator.SetBool("EnemyMove", false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
            _isPlayer = true;
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
            _isPlayer = false;
    }

    private void EnemyBehaviour()
    {
        if (_isPlayer == false)
        {
            transform.Translate(0, 0, _speedPatrol * Time.deltaTime);
            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;
            if (Physics.SphereCast(ray, 0.75f, out hit))
            {
                if (hit.distance < _obstacleRange)
                {
                    float angle = Random.Range(-110, 110);
                    transform.Rotate(0, angle, 0);
                }
            }
        }
        else
        {
            Vector3 tempDir = new Vector3(_target.position.x - transform.position.x, _target.position.y - transform.position.y, _target.position.z - transform.position.z);
            Vector3 dir = Vector3.RotateTowards(transform.forward, tempDir, _speedEnemy, 0.0f);
            transform.rotation = Quaternion.LookRotation(dir);
            transform.position = Vector3.MoveTowards(transform.position, _target.position, _speedEnemy);
        }
    }

    public void TakeDamage(float amount)
    {
        _health -= amount;
        if (_health <= 0f)
        {
            _isDeath = true;
            if (_isDeath == true)
            {
                _animator.SetBool("Death", true);
                transform.position = new Vector3(transform.position.x, -1f, transform.position.z);
            }
        }
    }    
    
}    




