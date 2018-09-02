namespace RApi.Controllers

open System
open System.Collections.Generic
open System.Linq
open System.Threading.Tasks
open Microsoft.AspNetCore.Mvc
open Rhino.Compute

[<Route("api/[controller]")>]
[<ApiController>]
type GeoController () =
    inherit ControllerBase()

    [<HttpGet>]
    member this.Get() =
        let apiToken = "matas@ubarevicius.lt"
        ComputeServer.ApiToken <- apiToken
        let sphere = new Rhino.Geometry.Sphere(Rhino.Geometry.Point3d.Origin, 12.0);
        let sphereAsBrep = sphere.ToBrep();
        let meshes = MeshCompute.CreateFromBrep(sphereAsBrep);
        let values ="The mesh has " + meshes.First().Vertices.Count.ToString() + " vertices"
        ActionResult<string>(values)

    [<HttpGet("{id}")>]
    member this.Get(id:int) =
        let value = "value"
        ActionResult<string>(value)

    [<HttpPost>]
    member this.Post([<FromBody>] value:string) =
        ()

    [<HttpPut("{id}")>]
    member this.Put(id:int, [<FromBody>] value:string ) =
        ()

    [<HttpDelete("{id}")>]
    member this.Delete(id:int) =
        ()
