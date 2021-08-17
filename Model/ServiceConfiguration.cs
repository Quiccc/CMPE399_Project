using System;

namespace ARD_project.Model
{
    public class ServiceConfiguration
    {
        public JwtSettings JwtSettings { get; set; }
    }
    public class JwtSettings
    {
        public string Secret { get; set; }

        public TimeSpan TokenLifetime { get; set; }
    }
}