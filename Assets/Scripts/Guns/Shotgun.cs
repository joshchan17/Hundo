using UnityEngine;

public class Shotgun : Gun{

    public float Force;

    protected override void OnFire()
    {
        var projectile = Instantiate(ProjectilePrefab, SpawnPoint.position, SpawnPoint.rotation);
        projectile.GetComponent<Rigidbody2D>().AddForce(projectile.transform.right * Force);

        var projectile2 = Instantiate(ProjectilePrefab, SpawnPoint.position, SpawnPoint.rotation);
        projectile2.GetComponent<Rigidbody2D>().AddForce(projectile2.transform.right * Force);

        var projectile3 = Instantiate(ProjectilePrefab, SpawnPoint.position, SpawnPoint.rotation);
        projectile3.GetComponent<Rigidbody2D>().AddForce(projectile3.transform.right * Force);

        var projectile4 = Instantiate(ProjectilePrefab, SpawnPoint.position, SpawnPoint.rotation);
        projectile4.GetComponent<Rigidbody2D>().AddForce(projectile4.transform.right * Force);


 
    }
}
