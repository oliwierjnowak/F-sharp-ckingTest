module EventService.Service

open System
open Npgsql
open Dapper

type Event = {
    Name : string 
    Price: int
}

let connectionString = "Host=localhost;Port=5432;Database=postgres;Username=postgres;Password=postgres;"

let getAllPeople () =
    use connection = new NpgsqlConnection(connectionString)
    connection.Query<Event>("SELECT Name, Price FROM Events")

let getAllEventsAsync () : Async<Event seq> =
    async {
        use connection = new NpgsqlConnection(connectionString)
        let! events = connection.QueryAsync<Event>("SELECT Name, Price FROM Events") |> Async.AwaitTask
        return events
    }
