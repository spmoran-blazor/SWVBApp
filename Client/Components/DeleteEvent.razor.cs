using Microsoft.AspNetCore.Components;
using MudBlazor;
using WVBApp.Shared.DTOs;
using WVBApp.Shared.Entities;
using WVBApp.Shared.Services.Data;
using WVBApp.Shared.Services.State;

namespace Client.Components
{
    public partial class DeleteEvent: IDisposable
    {
        [Inject] StateAccessService State { get; set; }
        [Inject] DataAccessService Data { get; set; }
        [Inject] ISnackbar Snackbar { get; set; }
        [Inject] IDialogService DialogService { get; set; }
        
        private DataAccessService? _data;
        private List<Event> _events = new List<Event>();
        private List<EventWithCodeInfo> _fullEvents = new List<EventWithCodeInfo>();
        private StateAccessService? _state;
        bool _success;
        protected override async Task OnInitializedAsync()
        {
            _state = State;
            _data = Data;
            await GetScheduledEvents();
        }

        private async void RemoveEvent(EventWithCodeInfo evc)
        {
            bool? result = await DialogService.ShowMessageBox("Warning", "Deleting can not be undone!", yesText: "Delete!", cancelText: "Cancel");
            if (result is not null && result == true)
            {
                Event? evt = _events.Where(a => a.Id == evc.Id).FirstOrDefault();
                var postData = await _data.DeleteEvent(evt);
                await GetScheduledEvents();
                _success = true;
                Snackbar.Configuration.PositionClass = "Top-Center";
                Snackbar.Add("Event Removed!", Severity.Success);
                StateHasChanged();
            }
        }

        private async Task GetScheduledEvents()
        {
            if (_data is not null)
            {
                var data = await _data.GetScheduledEvents();
                _fullEvents = data.ToList();
                await FashionEvents(_fullEvents);
                StateHasChanged();
            }
        }

        private async Task FashionEvents(List<WVBApp.Shared.DTOs.EventWithCodeInfo> eventWithCodeInfos)
        {
            _events.Clear();
            foreach (var item in eventWithCodeInfos)
            {
                Event evt = new Event();
                evt.Id = item.Id;
                evt.AreaOfPlayId = item.AreaOfPlayId;
                evt.IsPartial = item.IsPartial;
                evt.ParticipantLimit = item.ParticipantLimit;
                evt.PartialGameId = item.PartialGameId;
                evt.EventComment = item.EventComment ?? null;
                evt.EventDate = item.EventDate;
                evt.EventTime = item.EventTime;
                evt.EventSchedulingCodeId = item.EventSchedulingCodeId;
                evt.IsCancelled = item.IsCancelled;
                evt.UpdatedBy = item.UpdatedBy;
                evt.UpdatedDate = item.UpdatedDate;
                _events.Add(evt);
            }
        }

        void IDisposable.Dispose()
        {
            _data = null;
            _state = null;
        }
    }
}