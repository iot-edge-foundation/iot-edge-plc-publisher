# IoT Edge PLC Publisher 

This project aims to provide an Azure IoT Edge module for publishing PLC Tags values to Azure IoT Edge and Azure IoT Hub.

## Usage

To use the module, you need to deploy the following Azure IoT Edge module:

```json
 "PlcPublisher": {
        "restartPolicy": "always",
        "settings": {
            "image": "ghcr.io/kbeaugrand/azure-iotedge-plc-publisher:latest",
            "createOptions": "{}"
        },
        "status": "running",
        "type": "docker"
    }
```

### Edge Hub routing

```json
    "routes": {
        "PlcPublisherToUpstream": "FROM /messages/modules/PlcPublisher/* INTO $upstream",
    },
```

### Supported PLCs

It can be one of the following values:

- ``ControlLogix``: Control Logix-class PLC
- ``Plc5``: PLC/5 PLC
- ``Slc500``: SLC 500 PLC
- ``LogixPccc``: Control Logix-class PLC using the PLC/5 protocol
- ``Micro800``: Micro 800 PLC
- ``MicroLogix``: Micro Logix PLC
- ``Omron``: Omron PLC

### Supported Tag Types

It can be one of the following values:

- ``BOOL``: Boolean
- ``SINT``: Signed 8-bit integer
- ``INT``: Signed 16-bit integer
- ``DINT``: Signed 32-bit integer
- ``LINT``: Signed 64-bit integer
- ``LREAL``: Signed 64-bit floating point
- ``REAL``: Signed 32-bit floating point
- ``STRING``: String
- ``ARRAY_BOOL``: Array of boolean
- ``ARRAY_SINT``: Array of signed 8-bit integer
- ``ARRAY_INT``: Array of signed 16-bit integer
- ``ARRAY_DINT``: Array of signed 32-bit integer
- ``ARRAY_LINT``: Array of signed 64-bit integer
- ``ARRAY_LREAL``: Array of signed 64-bit floating point
- ``ARRAY_REAL``: Array of signed 32-bit floating point
- ``ARRAY_STRING``: Array of string

### Direct Methods

This module exposes the following direct methods:

- `ListTags`: List all the tags available in the PLC.
- `ListUdtTypes`: List all the UDT types available in the PLC.
- `ListPrograms`: List all the programs available in the PLC.
- `ReadTag`: Read a tag value.
- `ReadArray`: Read an array value.

### Payloads

For the `ListTags`, `ListUdtTypes` and `ListPrograms` methods, the payload is a JSON object with the following structure:

```json
{
    "gateway": "`<the gateway ip or hostname>`",
    "path": "<the path to the PLC>",
    "plcType": "<the PLC type>",
}
```

For ``ReadTag``, the payload is a JSON object with the following structure:

```json
{
    "gateway": "`<the gateway ip or hostname>`",
    "path": "<the path to the PLC>",
    "plcType": "<the PLC type>",
    "tag": "<the tag name>",
    "tagType": "<the tag type>"
}
```

For ``ReadArray``, the payload is a JSON object with the following structure:

```json
{
    "gateway": "`<the gateway ip or hostname>`",
    "path": "<the path to the PLC>",
    "plcType": "<the PLC type>",
    "tag": "<the tag name>",
    "tagType": "<the tag type>",
    "arrayLength": "<the array size>",
}
```

### Module Twin

The module accepts the following properties in the module twin:

```json
{
    "properties": {
        "desired": {
            "tags": [
                "gateway": "`<the gateway ip or hostname>`",
                "path": "<the path to the PLC>",
                "plcType": "<the PLC type>",
                "tag": "<the tag name>",
                "tagType": "<the tag type>",
                "pollingInterval": "<the polling interval in milliseconds>"
                "arrayLength": "<OPTIONAL - the array size if reading an array>",
            ]
        }
    }
}
```

## Credits

This project leverages on [https://github.com/libplctag/libplctag.NET](https://github.com/libplctag/libplctag.NET) to provide connectivity to the PLC devices.

## License

This project is licensed under the MIT License (see [./LICENSE.md](LICENSE.md)) for more details.
