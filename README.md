# NavEditor
User Interface to edit ILS and LOC Approaches for Infinite Flight. Simply have the [Airports](https://github.com/InfiniteFlightAirportEditing/Airports) repo and your fork of the [Navigation](https://github.com/InfiniteFlightAirportEditing/Navigation) repo cloned to your PC, install NavEditor from the releases, then open it and away you go.

## How to Use

NavEditor is designed to be simple and resourceful. It uses your local copy of the Airports to fetch much of the data required to edit approaches. All you need to verify is the Approach Identifier, Frequency, Runway, and Glideslope Angle (ILSes only). Even if everything is correct, hit save anyway to ensure the automatic properties are set correctly (elevation, lat/lon, etc).

## Contributing

This application is licensed under the [Apache 2.0 License](https://github.com/Velocity23/NavEditor/blob/master/LICENSE). You are welcome to make modifications for your own uses, and if you wish to contribute just open a PR and I'll take a look.

## Adding & Removing Approaches

Currently it is not possible to add or remove approaches. This must be done manually in the LOC and Glideslope files. 

