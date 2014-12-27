// Guids.cs
// MUST match guids.h
using System;

namespace memamjome.AppveyorVSPackage
{
    static class GuidList
    {
        public const string guidAppveyorVSPackagePkgString = "cd9d22d3-d88a-45f5-aba9-60df2ce68971";
        public const string guidAppveyorVSPackageCmdSetString = "33d5c1d2-fcd3-4ef3-a6f8-9a924ab7af1c";
        public const string guidToolWindowPersistanceString = "ee3d7c47-e28f-4fb0-930e-a11447cf0046";

        public static readonly Guid guidAppveyorVSPackageCmdSet = new Guid(guidAppveyorVSPackageCmdSetString);
    };
}