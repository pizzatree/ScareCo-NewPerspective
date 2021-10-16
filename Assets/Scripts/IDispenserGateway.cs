using System;

public interface IDispenserGateway
{
    event Action OnGatewayCleared;
}