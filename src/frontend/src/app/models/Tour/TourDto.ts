import { UserDto } from '../UserDto';

export class TourDto {
    id: number;
    date: Date;
    title: string;
    description: string;
    movementType: string;
    gatheringPlace: string;
    destinationLocation: string;
    creatorUser: UserDto;
    tourParticipants: UserDto[];
}