using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private float _health;
    private bool _isDead = false;
    private void Update()
    {
        if (!_isDead)
        {
            EnemyAnimator();            
        }
        else
        {
            _animator.SetBool("Death", true);
            transform.position = new Vector3(transform.position.x, -1f, transform.position.z);
        }
    }
    private void EnemyAnimator()
    {
        _animator.SetBool("EnemyMove",false);
    }    
    public void TakeDamage(float amount)
    {
        _health -= amount;
        if (_health <= 0f)        
            _isDead = true;           
    }
}
