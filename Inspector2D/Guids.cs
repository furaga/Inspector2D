// Guids.cs
// MUST match guids.h
using System;

namespace Company.Inspector2D
{
    static class GuidList
    {
        public const string guidInspector2DPkgString = "ea747a1a-929c-49df-8aad-4ccf05f720db";
        public const string guidInspector2DCmdSetString = "eb5b038d-2152-409f-80e7-001ab8c595a1";
        public const string guidToolWindowPersistanceString = "90d68a47-5599-4271-ac2a-09def630f348";

        public static readonly Guid guidInspector2DCmdSet = new Guid(guidInspector2DCmdSetString);
    };
}