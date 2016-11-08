﻿using GitHub.Primitives;
using GitHub.Services;
using System;

namespace GitHub.VisualStudio.Menus
{
    public class LinkMenuBase: MenuBase
    {
        readonly Lazy<IUsageTracker> usageTracker;

        protected IUsageTracker UsageTracker => usageTracker.Value;

        public LinkMenuBase(IUIProvider serviceProvider)
            : base(serviceProvider)
        {
            usageTracker = new Lazy<IUsageTracker>(() => ServiceProvider.TryGetService<IUsageTracker>());
        }

        protected UriString GenerateLink()
        {
            var repo = ActiveRepo;
            var activeDocument = ServiceProvider.TryGetService<IActiveDocumentSnapshot>();
            if (activeDocument == null)
                return null;
            return repo.GenerateUrl(activeDocument.Name, activeDocument.StartLine, activeDocument.EndLine);
        }
    }
}
