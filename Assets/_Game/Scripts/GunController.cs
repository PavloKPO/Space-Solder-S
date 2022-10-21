using UnityEngine;

public class GunController : MonoBehaviour
{
    [SerializeField] private float _damage;
    [SerializeField] private float _rangeAttack;
    [SerializeField] private Transform _pointOfAttack;
    [SerializeField] private ParticleSystem _muzzleFlash;
    [SerializeField] private GameObject _impactEffect;    
    private void Update()
    {
        if (Input.GetButtonDown("Fire2"))                   
            Shoot();        
    }
    public void Shoot()
    {   
        _muzzleFlash.Play();
        RaycastHit hit;             
        if (Physics.Raycast(_pointOfAttack.position, _pointOfAttack.forward, out hit, _rangeAttack))
        {
            EnemyController target = hit.transform.GetComponent<EnemyController>();
            if (target != null)
            {
                target.TakeDamage(_damage);
            }

            GameObject impactGO = Instantiate(_impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactGO, 0.5f);
        }                
    }    
}
