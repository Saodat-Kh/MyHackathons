using Domain.Dto.Participant;
using Domain.Dto.Team;
using Domain.Responses;

namespace Infrastructure.Interfaces;

public interface IParticipantService
{
    Response<string> CreateParticipant(CreateParticipantDto dto);
    Response<string> UpdateParticipant(int id, UpdateParticipantDto dto);
    Response<string> DeleteParticipant(int  id);
    Response<List<GetParticipantDto>> GetAllParticipants();
    Response<GetParticipantDto>  GetParticipantById(int id);
}