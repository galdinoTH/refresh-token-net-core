﻿namespace RefreshToken.Core.Crosscutting.Domain.Controller;

public class SuccessResponse<TResponseData>
{
    public bool Success => true;

    public TResponseData Data { get; }

    public SuccessResponse(TResponseData data)
    {
        Data = data;
    }
}
