// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using System.ComponentModel.DataAnnotations;

namespace IdentityServerHost.Quickstart.UI
{
    public class ExternalProvider
    {
        [Key]
        public int Id { get; set; }
        public string DisplayName { get; set; }
        public string AuthenticationScheme { get; set; }
    }
}